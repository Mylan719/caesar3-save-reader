using CeasarSaveReader.Figures.Model;
using CeasarSaveReader.Loader;

namespace CeasarSaveReader.Figures
{
    public class FigureLoader : ItemLoaderBase<Figure, FigureState>
    {
        protected override Figure LoadItem(BinaryReader reader, int bufferSize, int saveVersion)
        {
            var f = new Figure();
            f.alternative_location_index = reader.ReadByte();
            f.image_offset = reader.ReadByte();
            f.is_enemy_image = reader.ReadByte();
            f.flotsam_visible = reader.ReadByte();
            f.image_id = (uint)reader.ReadInt16();
            f.cart_image_id = (uint)reader.ReadInt16();
            f.next_figure_id_on_same_tile = reader.ReadInt16();
            f.type = (FigureType)reader.ReadByte();
            f.resource_id = reader.ReadByte();
            f.use_cross_country = reader.ReadByte();
            f.is_friendly = reader.ReadByte();
            f.state = (FigureState)reader.ReadByte();
            f.faction_id = reader.ReadByte();
            f.action_state_before_attack = reader.ReadByte();
            f.direction = reader.ReadSByte(); ;
            f.previous_tile_direction = reader.ReadSByte();
            f.attack_direction = reader.ReadSByte(); ;
            f.Coordinates = new Map.GridOffset(reader.ReadByte(), reader.ReadByte());
            f.previous_tile_x = reader.ReadByte();
            f.previous_tile_y = reader.ReadByte();
            f.missile_damage = reader.ReadByte();
            f.damage = reader.ReadByte();
            f.GlobalCoordinates = new Map.GridOffset(reader.ReadInt16());
            f.Destination = new Map.GridOffset(reader.ReadByte(), reader.ReadByte());
            f.GlobalDestination = new Map.GridOffset(reader.ReadInt16());
            f.Source = new Map.GridOffset(reader.ReadByte(), reader.ReadByte());
            f.formation_position_x.soldier = reader.ReadByte();
            f.formation_position_y.soldier = reader.ReadByte();
            f.disallow_diagonal = reader.ReadInt16();
            f.wait_ticks = reader.ReadInt16();
            f.ActionState = (ActionState)reader.ReadByte();
            f.progress_on_tile = reader.ReadByte();
            f.routing_path_id = reader.ReadInt16();
            f.routing_path_current_tile = reader.ReadInt16();
            f.routing_path_length = reader.ReadInt16();
            f.in_building_wait_ticks = reader.ReadByte();
            f.IsOnRoad = reader.ReadByte() > 0;
            f.MaxRoamLength = reader.ReadInt16();
            f.roam_length = reader.ReadInt16();
            f.roam_choose_destination = reader.ReadByte();
            f.roam_random_counter = reader.ReadByte();
            f.roam_turn_direction = reader.ReadSByte(); ;
            f.roam_ticks_until_next_turn = reader.ReadSByte(); ;
            f.cross_country_x = reader.ReadInt16();
            f.cross_country_y = reader.ReadInt16();
            f.cc_destination_x = reader.ReadInt16();
            f.cc_destination_y = reader.ReadInt16();
            f.cc_delta_x = reader.ReadInt16();
            f.cc_delta_y = reader.ReadInt16();
            f.cc_delta_xy = reader.ReadInt16();
            f.cc_direction = reader.ReadByte();
            f.speed_multiplier = reader.ReadByte();
            f.building_id = reader.ReadInt16();
            f.immigrant_building_id = reader.ReadInt16();
            f.destination_building_id = reader.ReadInt16();
            f.formation_id = reader.ReadInt16();
            f.index_in_formation = reader.ReadByte();
            f.formation_at_rest = reader.ReadByte();
            f.migrant_num_people = reader.ReadByte();
            f.is_ghost = reader.ReadByte();
            f.min_max_seen = reader.ReadByte();
            f.progress_to_next_tick = reader.ReadSByte();
            f.leading_figure_id = reader.ReadInt16();
            f.attack_image_offset = reader.ReadByte();
            f.wait_ticks_missile = reader.ReadByte();
            f.x_offset_cart = reader.ReadSByte(); ;
            f.y_offset_cart = reader.ReadSByte(); ;
            f.empire_city_id = reader.ReadByte();
            f.trader_amount_bought = reader.ReadByte();
            f.name = reader.ReadInt16();
            f.TerrainUsage = (TerrainUsage)reader.ReadByte();
            f.loads_sold_or_carrying = reader.ReadByte();
            f.Floating = (FloatingType)reader.ReadByte();
            f.height_adjusted_ticks = reader.ReadByte();
            f.current_height = reader.ReadByte();
            f.target_height = reader.ReadByte();
            f.collecting_item_id = reader.ReadByte();
            f.trade_ship_failed_dock_attempts = reader.ReadByte();
            f.phrase_sequence_exact = reader.ReadByte();
            f.phrase_id = reader.ReadSByte(); ;
            f.phrase_sequence_city = reader.ReadByte();
            f.trader_id = reader.ReadByte();
            f.wait_ticks_next_target = reader.ReadByte();
            f.dont_draw_elevated = reader.ReadByte();
            f.target_figure_id = reader.ReadInt16();
            f.targeted_by_figure_id = reader.ReadInt16();
            f.created_sequence = reader.ReadUInt16();
            f.target_figure_created_sequence = reader.ReadUInt16();
            f.figures_on_same_tile_index = reader.ReadByte();
            f.num_attackers = reader.ReadByte();
            f.attacker_id1 = reader.ReadInt16();
            f.attacker_id2 = reader.ReadInt16();
            f.opponent_id = reader.ReadInt16();

            // The following code should only be executed if the savegame includes figure information that is not 
            // supported on this specific version of Augustus. The extra bytes in the buffer must be skipped in order
            // to prevent reading bogus data for the next figure
            if (bufferSize > Constants.CURRENT_BUFFER_SIZE)
            {
                reader.ReadBytes(bufferSize - Constants.CURRENT_BUFFER_SIZE);
            }
            return f;
        }
    }
}
