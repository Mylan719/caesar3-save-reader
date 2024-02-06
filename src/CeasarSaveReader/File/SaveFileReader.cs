using CeasarSaveReader.Buildings;
using CeasarSaveReader.Buildings.Bridge;
using CeasarSaveReader.Buildings.Model;
using CeasarSaveReader.City;
using CeasarSaveReader.Figures;
using CeasarSaveReader.Figures.Model;
using CeasarSaveReader.Figures.Paths;
using CeasarSaveReader.Map;
using CeasarSaveReader.Scenario;
using CeasarSaveReader.Scenario.Model;
using CeasarSaveReader.Terrain;
using CeasarSaveReader.Tools;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace CeasarSaveReader.File
{
    public class SaveFileReader
    {
        private SavegameData? data;

        public GameSave ReadSave(string filename, int offset)
        {
            data = new SavegameData();

            using var file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(file);

            if (offset > 0)
            {
                reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            }

            int version = GetGameVersion(reader);
            if (version > 0)
            {
                if (version > Constants.SAVE_GAME_CURRENT_VERSION)
                {
                    throw new Exception($"Newer save game version than supported. Please update your Augustus. Version: {version}");
                }
                data.state = init_savegame_data(version);
                ReadSave(reader, version);
            }

            return savegame_load_from_state(version);
        }

        private GameSave savegame_load_from_state(int version)
        {
            var gameSave = new GameSave();

            gameSave.Scenario = LoadScenario();
            gameSave.Terrain = LoadGrid(data.state.terrain_grid.Data, gameSave.Scenario.map, r => (TerrainType)r.ReadUInt16());
            gameSave.BuildingGrid = LoadGrid(data.state.building_grid.Data, gameSave.Scenario.map, r => (int)r.ReadUInt16());
            gameSave.FigureGrid = LoadGrid(data.state.figure_grid.Data, gameSave.Scenario.map, r => (int)r.ReadUInt16());
            gameSave.BuildingsDamage = LoadGrid(data.state.building_damage_grid.Data, gameSave.Scenario.map, r => (int)r.ReadByte());
            gameSave.Elevation = LoadGrid(data.state.elevation_grid.Data, gameSave.Scenario.map, r => (int)r.ReadByte());
            gameSave.Desirability = LoadGrid(data.state.desirability_grid.Data, gameSave.Scenario.map, r => (int)r.ReadByte());
            gameSave.EdgeGrid = LoadGrid(data.state.edge_grid.Data, gameSave.Scenario.map, r => (EdgeType)r.ReadByte());
            gameSave.BitField = LoadGrid(data.state.bitfields_grid.Data, gameSave.Scenario.map, r => (BitType)r.ReadByte());
            gameSave.Sprite = LoadGrid(data.state.sprite_grid.Data, gameSave.Scenario.map, r => (int)r.ReadByte());
            gameSave.City = LoadCity();
            gameSave.Buildings = LoadBuildings(version);
            gameSave.Figures = LoadFigures(version);
            gameSave.Paths = LoadPaths();
            gameSave.Bridges = GetBridgeTiles(gameSave);

            return gameSave;
        }

        private Grid<TItem> LoadGrid<TItem>(byte[] data, Scenario.Model.Map map, Func<BinaryReader, TItem> itemReadFunc)
            where TItem : struct
        {
            using var stream = new MemoryStream(data);
            using var reader = new BinaryReader(stream);

            var grid = new Grid<TItem>(map.GridStart, map.Size);
            for (int i = 0; i < grid.Tiles.Length; i++)
            {
                grid.Tiles[i] = itemReadFunc(reader);
            }
            return grid;
        }

        private ScenarioData LoadScenario()
        {
            using var stream = new MemoryStream(data.state.scenario.Data);

            return new ScenarioLoader().Load(stream);
        }

        private List<Figures.Model.Figure> LoadFigures(int version)
        {
            using var figureStream = new MemoryStream(data.state.figures.Data);
            using var sequenceStream = new MemoryStream(data.state.figure_sequence.Data);

            return new FigureLoader().Load(figureStream, sequenceStream, 
                version > Constants.SAVE_GAME_LAST_STATIC_VERSION,
                version );
        }

        private List<FigurePathData> LoadPaths()
        {
            using var routefigureStream = new MemoryStream(data.state.route_figures.Data);
            using var pathStream = new MemoryStream(data.state.route_paths.Data);

            return new FigurePathLoader().Load(routefigureStream, pathStream);
        }

        private List<Buildings.Model.Building> LoadBuildings(int version)
        {
            using var buildingsStream = new MemoryStream(data.state.buildings.Data);
            using var buildingsExtraStream = new MemoryStream(data.state.building_extra_sequence.Data);
            using var buildingsExtraCorruptHousesStream = new MemoryStream(data.state.building_extra_corrupt_houses.Data);

            return new BuildingLoader().Load(
                buildingsStream,
                buildingsExtraStream,
                version > Constants.SAVE_GAME_LAST_STATIC_VERSION,
                version);
        }

        private static List<BridgeTile> GetBridgeTiles(GameSave gameSave)
        {
            return gameSave.Terrain
                .ForTile((coords, terrain) => new { Coordinates = coords, Sprite = gameSave.Sprite[coords], IsBridge = terrain.IsRoad() && terrain.IsWater() })
                .Where(b => b.IsBridge)
                .Select(b => new BridgeTile
                {
                    Coordinates = b.Coordinates,
                    BridgeSection = b.Sprite.GetBridgeSectionType(),
                    Type = b.Sprite.GetBridgeType(),
                    Orientation = b.Sprite.GetBridgeOrientation()
                }).ToList();
        }

        private CityData LoadCity()
        {
            using var stream = new MemoryStream(data.state.city_data.Data);
            return CityLoader.LoadMainData(stream, false);
        }

        private int GetGameVersion(BinaryReader file)
        {
            try
            {
                file.BaseStream.Seek(4, SeekOrigin.Current);
                var version = (int)file.ReadUInt32();
                file.BaseStream.Seek(0, SeekOrigin.Begin);
                return version;
            }
            catch
            {
                return 0;
            }
        }

        private void ReadSave(BinaryReader reader, int version)
        {
            foreach (var piece in data.pieces)
            {
                if (!prepare_dynamic_piece(reader, piece))
                {
                    continue;
                }
                if (piece.compressed)
                {
                    piece.Data = ReadCompressedChunk(reader, piece, version);
                }
                else
                {
                    piece.Data = reader.ReadBytes(piece.Size);
                }
            }
        }

        private bool prepare_dynamic_piece(BinaryReader reader, FilePiece piece)
        {
            if (piece.dynamic)
            {
                piece.Size = reader.ReadInt32();
                if (piece.Size > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private byte[] ReadCompressedChunk(BinaryReader reader, FilePiece piece, int version)
        {
            int input_size = reader.ReadInt32();
            if ((uint)input_size == Constants.UNCOMPRESSED)
            {
                return reader.ReadBytes(piece.Size);
            }
            else
            {
                var compressedChunk = reader.ReadBytes(input_size);

                if (version <= Constants.SAVE_GAME_LAST_ZIP_COMPRESSION)
                {

                    return ZipDecompress(compressedChunk, piece.Size);
                }
                else
                {
                    return ZlibDecompress(compressedChunk, piece.Size);
                }
            }
        }

        private byte[] ZipDecompress(byte[] compressedBytes, int expectedSize)
        {
            using var inputStream = new MemoryStream(compressedBytes);
            using var pkwareInputStream = new PkwareInputStream(inputStream, compressedBytes.Length);

            var decompressed = new byte[expectedSize];
            var read = pkwareInputStream.Read(decompressed, 0, expectedSize);
            if (read < expectedSize) throw new IOException($"Could not read compressed chunk to the end. Expected size: {expectedSize} Actual size: {read}.");
            return decompressed;
        }

        private byte[] ZlibDecompress(byte[] compressedBytes, int expectedSize)
        {
            using var inputStream = new MemoryStream(compressedBytes);
            using var stream = new DeflateStream(inputStream, CompressionMode.Decompress);

            var decompressed = new byte[expectedSize];
            stream.Read(decompressed, 0, decompressed.Length);
            return decompressed;
        }

        private SavegameState init_savegame_data(int version)
        {
            var version_data = get_version_data(version);

            var state = new SavegameState();
            state.scenario_campaign_mission = create_savegame_piece(4, false);
            state.file_version = create_savegame_piece(4, false);
            if (version_data.has_image_grid)
            {
                state.image_grid = create_savegame_piece(version_data.piece_sizes.image_grid, true);
            }
            state.edge_grid = create_savegame_piece(26244, true);
            state.building_grid = create_savegame_piece(52488, true);
            state.terrain_grid = create_savegame_piece(version_data.piece_sizes.terrain_grid, true);
            state.aqueduct_grid = create_savegame_piece(26244, true);
            state.figure_grid = create_savegame_piece(52488, true);
            state.bitfields_grid = create_savegame_piece(26244, true);
            state.sprite_grid = create_savegame_piece(26244, true);
            state.random_grid = create_savegame_piece(26244, false);
            state.desirability_grid = create_savegame_piece(26244, true);
            state.elevation_grid = create_savegame_piece(26244, true);
            state.building_damage_grid = create_savegame_piece(26244, true);
            state.aqueduct_backup_grid = create_savegame_piece(26244, true);
            state.sprite_backup_grid = create_savegame_piece(26244, true);
            state.figures = create_savegame_piece(version_data.piece_sizes.figures, true);
            state.route_figures = create_savegame_piece(version_data.piece_sizes.route_figures, true);
            state.route_paths = create_savegame_piece(version_data.piece_sizes.route_paths, true);
            state.formations = create_savegame_piece(version_data.piece_sizes.formations, true);
            state.formation_totals = create_savegame_piece(12, false);
            state.city_data = create_savegame_piece(36136, true);
            state.city_faction_unknown = create_savegame_piece(2, false);
            state.player_name = create_savegame_piece(64, false);
            state.city_faction = create_savegame_piece(4, false);
            state.buildings = create_savegame_piece(version_data.piece_sizes.buildings, true);
            state.city_view_orientation = create_savegame_piece(4, false);
            state.game_time = create_savegame_piece(20, false);
            state.building_extra_highest_id_ever = create_savegame_piece(8, false);
            state.random_iv = create_savegame_piece(8, false);
            state.city_view_camera = create_savegame_piece(8, false);
            state.building_count_culture1 = create_savegame_piece(version_data.building_counts.culture1, false);
            state.city_graph_order = create_savegame_piece(8, false);
            state.emperor_change_time = create_savegame_piece(8, false);
            state.empire = create_savegame_piece(12, false);
            state.empire_cities = create_savegame_piece(2706, true);
            state.building_count_industry = create_savegame_piece(version_data.building_counts.industry, false);
            state.trade_prices = create_savegame_piece(128, false);
            state.figure_names = create_savegame_piece(84, false);
            state.culture_coverage = create_savegame_piece(60, false);
            state.scenario = create_savegame_piece(1720, false);
            state.max_game_year = create_savegame_piece(4, false);
            state.earthquake = create_savegame_piece(60, false);
            state.emperor_change_state = create_savegame_piece(4, false);
            state.messages = create_savegame_piece(16000, true);
            state.message_extra = create_savegame_piece(12, false);
            state.population_messages = create_savegame_piece(10, false);
            state.message_counts = create_savegame_piece(80, false);
            state.message_delays = create_savegame_piece(80, false);
            state.building_list_burning_totals = create_savegame_piece(version_data.piece_sizes.burning_totals, false);
            state.figure_sequence = create_savegame_piece(4, false);
            state.scenario_settings = create_savegame_piece(12, false);
            state.invasion_warnings = create_savegame_piece(3232, true);
            state.scenario_is_custom = create_savegame_piece(4, false);
            state.city_sounds = create_savegame_piece(8960, false);
            state.building_extra_highest_id = create_savegame_piece(4, false);
            state.figure_traders = create_savegame_piece(4804, false);
            state.building_list_burning = create_savegame_piece(version_data.piece_sizes.building_list_burning, true);
            state.building_list_small = create_savegame_piece(version_data.piece_sizes.building_list_small, true);
            state.building_list_large = create_savegame_piece(version_data.piece_sizes.building_list_large, true);
            state.tutorial_part1 = create_savegame_piece(32, false);
            state.building_count_military = create_savegame_piece(version_data.building_counts.military, false);
            state.enemy_army_totals = create_savegame_piece(20, false);
            state.building_storages = create_savegame_piece(version_data.piece_sizes.building_storages, false);
            state.building_count_culture2 = create_savegame_piece(version_data.building_counts.culture2, false);
            state.building_count_support = create_savegame_piece(version_data.building_counts.support, false);
            state.tutorial_part2 = create_savegame_piece(4, false);
            state.gladiator_revolt = create_savegame_piece(16, false);
            state.trade_route_limit = create_savegame_piece(1280, true);
            state.trade_route_traded = create_savegame_piece(1280, true);
            state.building_barracks_tower_sentry = create_savegame_piece(4, false);
            state.building_extra_sequence = create_savegame_piece(4, false);
            state.routing_counters = create_savegame_piece(16, false);
            state.building_count_culture3 = create_savegame_piece(version_data.building_counts.culture3, false);
            state.enemy_armies = create_savegame_piece(900, false);
            state.city_entry_exit_xy = create_savegame_piece(16, false);
            state.last_invasion_id = create_savegame_piece(2, false);
            state.building_extra_corrupt_houses = create_savegame_piece(8, false);
            state.scenario_name = create_savegame_piece(65, false);
            state.bookmarks = create_savegame_piece(32, false);
            state.tutorial_part3 = create_savegame_piece(4, false);
            state.city_entry_exit_grid_offset = create_savegame_piece(8, false);
            state.end_marker = create_savegame_piece(284, false); // 71x 4-bytes emptiness
            if (version_data.has_monument_deliveries)
            {
                state.deliveries = create_savegame_piece(version_data.piece_sizes.monument_deliveries, false);
            }
            return state;
        }

        static SavegameVersionData get_version_data(int version)
        {
            var version_data = new SavegameVersionData();
            int multiplier = 1;
            int count_multiplier = 1;
            version_data.piece_sizes.burning_totals = 8;
            if (version > Constants.SAVE_GAME_LAST_ORIGINAL_LIMITS_VERSION)
            {
                multiplier = 5;
            }
            if (version > Constants.SAVE_GAME_LAST_STATIC_VERSION)
            {
                multiplier = Constants.PIECE_SIZE_DYNAMIC;
                version_data.piece_sizes.burning_totals = 4;
            }

            if (version > Constants.SAVE_GAME_LAST_STATIC_BUILDING_COUNT_VERSION)
            {
                count_multiplier = Constants.PIECE_SIZE_DYNAMIC;
            }

            version_data.piece_sizes.image_grid = 52488 * (version > Constants.SAVE_GAME_LAST_SMALLER_IMAGE_ID_VERSION ? 2 : 1);
            version_data.piece_sizes.terrain_grid = 52488 * (version > Constants.SAVE_GAME_LAST_ORIGINAL_TERRAIN_DATA_SIZE_VERSION ? 2 : 1);
            version_data.piece_sizes.figures = 128000 * multiplier;
            version_data.piece_sizes.route_figures = 1200 * multiplier;
            version_data.piece_sizes.route_paths = 300000 * multiplier;
            version_data.piece_sizes.formations = 6400 * multiplier;
            version_data.piece_sizes.buildings = 256000 * multiplier;
            version_data.piece_sizes.building_list_burning = 1000 * multiplier;
            version_data.piece_sizes.building_list_small = 1000 * multiplier;
            version_data.piece_sizes.building_list_large = 4000 * multiplier;
            version_data.piece_sizes.building_storages = 6400 * multiplier;
            version_data.piece_sizes.monument_deliveries = version > Constants.SAVE_GAME_LAST_STATIC_MONUMENT_DELIVERIES_VERSION ?
                Constants.PIECE_SIZE_DYNAMIC : 3200;

            version_data.building_counts.culture1 = 132 * count_multiplier;
            version_data.building_counts.culture2 = 32 * count_multiplier;
            version_data.building_counts.culture3 = 40 * count_multiplier;
            version_data.building_counts.military = 16 * count_multiplier;
            version_data.building_counts.industry = 128 * count_multiplier;
            version_data.building_counts.support = 24 * count_multiplier;

            version_data.has_image_grid = version <= Constants.SAVE_GAME_LAST_STORED_IMAGE_IDS;
            version_data.has_monument_deliveries = version > Constants.SAVE_GAME_LAST_NO_DELIVERIES_VERSION;

            return version_data;
        }

        private FilePiece create_savegame_piece(int size, bool isCompressed)
        {
            var piece = new FilePiece();
            piece.compressed = isCompressed;
            piece.dynamic = size == Constants.PIECE_SIZE_DYNAMIC;
            piece.Size = size;

            data.pieces.Add(piece);
            return piece;
        }
    }
}
