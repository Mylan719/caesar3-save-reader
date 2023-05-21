using CeasarSaveReader.Buildings.Model;
using CeasarSaveReader.Loader;
using CeasarSaveReader.Map;
using CeasarSaveReader.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Buildings
{
    public class BuildingLoader : ItemLoaderBase<Building, BuildingState>
    {
        protected override Building LoadItem(BinaryReader reader, int building_buf_size, int saveVersion)
        {
            var b = new Building();
            b.state = (BuildingState)reader.ReadByte();
            b.faction_id = reader.ReadByte();
            b.unknown_value = reader.ReadByte();
            b.size = reader.ReadByte();
            b.HouseIsMerged = reader.ReadByte() > 0;
            b.house_size = reader.ReadByte();
            b.Coordinates = new GridOffset(reader.ReadByte(), reader.ReadByte());
            b.GlobalCoordinates = new GridOffset(reader.ReadInt16());
            b.type = (BuildingType)reader.ReadInt16();
            b.subtype.house_level = reader.ReadInt16(); // which union field we use does not matter
            b.road_network_id = reader.ReadByte();
            b.monthly_levy = reader.ReadByte();
            b.created_sequence = reader.ReadUInt16();
            b.houses_covered = reader.ReadInt16();
            b.percentage_houses_covered = reader.ReadInt16();
            b.house_population = reader.ReadInt16();
            b.house_population_room = reader.ReadInt16();
            b.distance_from_entry = reader.ReadInt16();
            b.house_highest_population = reader.ReadInt16();
            b.house_unreachable_ticks = reader.ReadInt16();
            b.RoadAccess = new GridOffset(reader.ReadByte(), reader.ReadByte());
            b.figure_id = reader.ReadInt16();
            b.figure_id2 = reader.ReadInt16();
            b.immigrant_figure_id = reader.ReadInt16();
            b.figure_inside_building = reader.ReadInt16();
            b.figure_spawn_delay = reader.ReadByte();
            b.days_since_offering = reader.ReadByte();
            b.figure_roam_direction = reader.ReadByte();
            b.has_water_access = reader.ReadByte();
            b.house_tavern_wine_access = reader.ReadByte();
            b.house_tavern_meat_access = reader.ReadByte();
            b.prev_part_building_id = reader.ReadInt16();
            b.next_part_building_id = reader.ReadInt16();
            b.loads_stored = reader.ReadInt16();
            b.house_sentiment_message = reader.ReadByte();
            b.has_well_access = reader.ReadByte();
            b.num_workers = reader.ReadInt16();
            b.labor_category = reader.ReadByte();
            b.output_resource_id = (ResourceType)reader.ReadByte();
            b.has_road_access = reader.ReadByte() > 0;
            b.house_criminal_active = reader.ReadByte();
            b.damage_risk = reader.ReadInt16();
            b.fire_risk = reader.ReadInt16();
            b.fire_duration = reader.ReadInt16();
            b.fire_proof = reader.ReadByte();
            b.house_figure_generation_delay = reader.ReadByte();
            b.house_tax_coverage = reader.ReadByte();
            b.house_pantheon_access = reader.ReadByte();
            b.formation_id = reader.ReadInt16();
            b.data = read_type_data(reader, b.type, b.output_resource_id, saveVersion);
            b.tax_income_or_storage = reader.ReadInt32();
            b.house_days_without_food = reader.ReadByte();
            b.has_plague = reader.ReadByte();
            b.desirability = reader.ReadSByte();
            b.is_deleted = reader.ReadByte();
            b.is_adjacent_to_water = reader.ReadByte();
            b.storage_id = reader.ReadByte();
            b.sentiment.house_happiness = reader.ReadSByte(); // which union field we use does not matter
            b.show_on_problem_overlay = reader.ReadByte();


            // Wharves produce meat
            if (b.type == BuildingType.WHARF)
            {
                b.output_resource_id = ResourceType.MEAT;
            }

            if (building_buf_size < (int)BuildingState.STRIKES)
            {
                // Backwards compatibility fixes for sentiment update
                if (b.house_population > 0 && b.sentiment.house_happiness < 20)
                {
                    b.sentiment.house_happiness = 30;
                }

                // Backwards compatibility fixes for culture update
                if (b.type.building_monument_is_monument() && b.subtype.house_level > 0 && b.type != BuildingType.HIPPODROME && b.type <= BuildingType.LIGHTHOUSE)
                {
                    ((Monument)b.data).phase = b.subtype.house_level;
                }

                if ((b.type == BuildingType.HIPPODROME || b.type == BuildingType.COLOSSEUM) && ((Monument)b.data).phase == 0)
                {
                    ((Monument)b.data).phase = -1;
                }

                if (((b.type >= BuildingType.LARGE_TEMPLE_CERES && b.type <= BuildingType.LARGE_TEMPLE_VENUS) || b.type == BuildingType.ORACLE) && ((Monument)b.data).phase == 0)
                {
                    ((Monument)b.data).phase = -1;
                }

            }

            if (saveVersion < Constants.SAVE_GAME_ROADBLOCK_DATA_MOVED_FROM_SUBTYPE)
            {
                // Backwards compatibility - roadblock data used to be stored in b.subtype 
                if (b.type.building_type_is_roadblock())
                {
                    ((Roadblock)b.data).exceptions = b.subtype.orientation;
                }
            }

            // To keep backward savegame compatibility, only fill more recent building struct elements
            // if building_buf_size is the correct size when those elements are included
            // For example, if you add an int (4 bytes) to the building state struct, in order to check
            // if the samegame version has that new int, you should add the folloging code:
            // if (building_buf_size >= BULDING_STATE_ORIGINAL_BUFFER_SIZE + 4) {
            //    b.new_var = reader.ReadInt32();
            // }
            // Or even better:
            // if (building_buf_size >= BULDING_STATE_NEW_FEATURE_BUFFER_SIZE) {
            //    b.new_var = reader.ReadInt32();
            // }
            // Building state variables are automatically set to 0, so if the savegame version doesn't include
            // that information, you can be assured that the game will read it as 0

            if (building_buf_size >= (int)BuildingState.TOURISM_BUFFER_SIZE)
            {
                b.house_arena_gladiator = reader.ReadByte();
                b.house_arena_lion = reader.ReadByte();
                b.is_tourism_venue = reader.ReadByte();
                b.tourism_disabled = reader.ReadByte();
                b.tourism_income = reader.ReadByte();
                b.tourism_income_this_year = reader.ReadByte();
            }

            if (building_buf_size >= (int)BuildingState.VARIANTS_AND_UPGRADES)
            {
                b.variant = reader.ReadByte();
                b.upgrade_level = reader.ReadByte();
            }

            if (building_buf_size >= (int)BuildingState.STRIKES)
            {
                b.strike_duration_days = reader.ReadByte();
            }

            if (building_buf_size >= (int)BuildingState.SICKNESS)
            {
                b.sickness_level = reader.ReadByte();
                b.sickness_duration = reader.ReadByte();
                b.sickness_doctor_cure = reader.ReadByte();
                b.fumigation_frame = reader.ReadByte();
                b.fumigation_direction = reader.ReadByte();
            }

            //Depends on figures
            //if (
            //    (b.type == BuildingType.LIGHTHOUSE || b.type == BuildingType.CARAVANSERAI) &&
            //    b.figure_id2 > 0 &&
            //    for_preview &&
            //    figure_get(b.figure_id2).type != FIGURE_LABOR_SEEKER
            //)
            //{
            //    b.figure_id = b.figure_id2;
            //    b.figure_id2 = 0;
            //}

            // The following code should only be executed if the savegame includes building information that is not 
            // supported on this specific version of Augustus. The extra bytes in the buffer must be skipped in order
            // to prevent reading bogus data for the next building
            if (building_buf_size > (int)BuildingState.CURRENT_BUFFER_SIZE)
            {
                reader.ReadBytes(building_buf_size - (int)BuildingState.CURRENT_BUFFER_SIZE);
            }

            return b;
        }

        private static BuildingData read_type_data(BinaryReader reader, BuildingType buildingType, ResourceType output_resource_id, int version)
        {
            // This function should ALWAYS read 42 bytes.
            // The only exception is for Caravanserai on old savegame versions, which due to an oversight only read 41 bytes.
            // If you don't need to read 42 bytes, skip the unneeded ones.
            if (buildingType.IsHouse())
            {
                var house = new House();
                for (int i = 0; i < (int)InventoryType.MAX; i++)
                {
                    house.inventory[i] = reader.ReadInt16();
                }
                house.theater = reader.ReadByte();
                house.amphitheater_actor = reader.ReadByte();
                house.amphitheater_gladiator = reader.ReadByte();
                house.colosseum_gladiator = reader.ReadByte();
                house.colosseum_lion = reader.ReadByte();
                house.hippodrome = reader.ReadByte();
                house.school = reader.ReadByte();
                house.library = reader.ReadByte();
                house.academy = reader.ReadByte();
                house.barber = reader.ReadByte();
                house.clinic = reader.ReadByte();
                house.bathhouse = reader.ReadByte();
                house.hospital = reader.ReadByte();
                house.temple_ceres = reader.ReadByte();
                house.temple_neptune = reader.ReadByte();
                house.temple_mercury = reader.ReadByte();
                house.temple_mars = reader.ReadByte();
                house.temple_venus = reader.ReadByte();
                house.no_space_to_expand = reader.ReadByte();
                house.num_foods = reader.ReadByte();
                house.entertainment = reader.ReadByte();
                house.education = reader.ReadByte();
                house.health = reader.ReadByte();
                house.num_gods = reader.ReadByte();
                house.devolve_delay = reader.ReadByte();
                house.evolve_text_id = reader.ReadByte();
                // Do not place this after if (building_has_supplier_inventory(b.type) or after if (building_monument_is_monument(b))
                // Because Caravanserai is monument AND supplier building and resources_needed / inventory is same memory spot
                return house;
            }
            else if (buildingType == BuildingType.CARAVANSERAI)
            {
                var monument = new Monument();
                for (int i = 0; i < (int)ResourceType.MAX; i++)
                {
                    monument.resources_needed[i] = reader.ReadInt16();
                }
                monument.upgrades = reader.ReadInt32();
                monument.progress = reader.ReadInt16();
                monument.phase = reader.ReadInt16();
                monument.fetch_inventory_id = reader.ReadByte();
                // Old savegame versions had a bug where the caravanserai's building type data size was off by 1
                // Old save versions don't need to skip the byte, while new save versions do
                if (version >= Constants.SAVE_GAME_CARAVANSERAI_OFFSET_FIX)
                {
                    reader.ReadBytes(1);
                }
                // As above, Ceres and Venus temples are both monuments and suppliers
                return monument;
            }
            else if (buildingType == BuildingType.LARGE_TEMPLE_CERES || buildingType == BuildingType.LARGE_TEMPLE_VENUS)
            {
                var monument = new Monument();
                for (int i = 0; i < (int)ResourceType.MAX; i++)
                {
                    monument.resources_needed[i] = reader.ReadInt16();
                }
                monument.upgrades = reader.ReadInt32();
                monument.progress = reader.ReadInt16();
                monument.phase = reader.ReadInt16();
                if (monument.phase == 0)
                { // Compatibility fix
                    monument.phase = -1;
                }
                monument.fetch_inventory_id = reader.ReadByte();
                reader.ReadBytes(1);
                return monument;
            }
            else if (buildingType.building_has_supplier_inventory())
            {
                var market = new Market();
                reader.ReadBytes(2);
                for (int i = 0; i < (int)InventoryType.MAX; i++)
                {
                    market.inventory[i] = reader.ReadInt16();
                }
                market.pottery_demand = reader.ReadInt16();
                market.furniture_demand = reader.ReadInt16();
                market.oil_demand = reader.ReadInt16();
                market.wine_demand = reader.ReadInt16();
                reader.ReadBytes(6);
                market.fetch_inventory_id = reader.ReadByte();
                market.is_mess_hall = reader.ReadByte();
                reader.ReadBytes(8);

                return market;
            }
            else if (buildingType == BuildingType.GRANARY)
            {
                var granary = new Granary();

                reader.ReadBytes(2);
                for (int i = 0; i < (int)ResourceType.MAX; i++)
                {
                    granary.resource_stored[i] = reader.ReadInt16();
                }
                reader.ReadBytes(8);
                return granary;
            }
            else if (buildingType.building_monument_is_monument())
            {
                var monument = new Monument();

                for (int i = 0; i < (int)ResourceType.MAX; i++)
                {
                    monument.resources_needed[i] = reader.ReadInt16();
                }
                monument.upgrades = reader.ReadInt32();
                monument.progress = reader.ReadInt16();
                monument.phase = reader.ReadInt16();
                reader.ReadBytes(2);

                return monument;
            }
            else if (buildingType == BuildingType.DOCK)
            {
                var dock = new Dock();
                dock.queued_docker_id = reader.ReadInt16();
                dock.has_accepted_route_ids = reader.ReadByte();
                dock.accepted_route_ids = reader.ReadInt32();
                reader.ReadBytes(20);
                dock.num_ships = reader.ReadByte();
                reader.ReadBytes(2);
                dock.orientation = reader.ReadSByte();
                reader.ReadBytes(3);
                for (int i = 0; i < 3; i++)
                {
                    dock.docker_ids[i] = reader.ReadInt16();
                }
                dock.trade_ship_id = reader.ReadInt16();
                return dock;
            }
            else if (buildingType.building_type_is_roadblock())
            {
                var roadblock = new Roadblock();
                roadblock.exceptions = reader.ReadInt16();
                reader.ReadBytes(40);
                return roadblock;
            }
            else if (buildingType.is_industry_type(output_resource_id))
            {
                var industry = new Industry();
                industry.progress = reader.ReadInt16();
                reader.ReadBytes(11);
                industry.is_stockpiling = reader.ReadByte();
                industry.has_fish = reader.ReadByte();
                reader.ReadBytes(14);
                industry.blessing_days_left = reader.ReadByte();
                industry.orientation = reader.ReadByte();
                industry.has_raw_materials = reader.ReadByte() > 0;
                reader.ReadBytes(1);
                industry.curse_days_left = reader.ReadByte();
                if ((buildingType >= BuildingType.WHEAT_FARM && buildingType <= BuildingType.POTTERY_WORKSHOP) || buildingType == BuildingType.WHARF)
                {
                    industry.age_months = reader.ReadByte();
                    industry.average_production_per_month = reader.ReadByte();
                    industry.production_current_month = reader.ReadInt16();
                    reader.ReadBytes(2);
                }
                else
                {
                    reader.ReadBytes(6);
                }
                industry.fishing_boat_id = reader.ReadInt16();
                return industry;
            }
            else
            {
                var entertainment = new Entertainment();
                reader.ReadBytes(26);
                entertainment.num_shows = reader.ReadByte();
                entertainment.days1 = reader.ReadByte();
                entertainment.days2 = reader.ReadByte();
                entertainment.play = reader.ReadByte();
                reader.ReadBytes(12);

                return entertainment;
            }
        }
    }
}
