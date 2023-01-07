using CeasarSaveReader.Loader;
using CeasarSaveReader.Map;
using CeasarSaveReader.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Buildings.Model
{
    public class Building : ItemBase<BuildingState>
    {
        public uint last_update { get; set; }
        public byte faction_id { get; set; }
        public byte unknown_value { get; set; }
        public byte size { get; set; }
        public byte house_is_merged { get; set; }
        public byte house_size { get; set; }
        public BuildingType type { get; set; }
        public Subtype subtype { get; set; } = new Subtype();
        public BuildingData data { get; set; }
        public byte road_network_id { get; set; }
        public ushort created_sequence { get; set; }
        public short houses_covered { get; set; }
        public short percentage_houses_covered { get; set; }
        public short house_population { get; set; }
        public short house_population_room { get; set; }
        public short distance_from_entry { get; set; }
        public short house_highest_population { get; set; }
        public short house_unreachable_ticks { get; set; }
        public GridOffset road_access { get; set; }
        public short figure_id { get; set; }
        public short figure_id2 { get; set; } // labor seeker or market supplier
        public short immigrant_figure_id { get; set; }
        public short figure_inside_building { get; set; } // tower ballista, burning ruin prefect, doctor healing plague
        public byte figure_spawn_delay { get; set; }
        public byte days_since_offering { get; set; }
        public byte figure_roam_direction { get; set; }
        public byte has_water_access { get; set; }
        public short prev_part_building_id { get; set; }
        public short next_part_building_id { get; set; }
        public short loads_stored { get; set; }
        public byte house_sentiment_message { get; set; }
        public byte has_well_access { get; set; }
        public short num_workers { get; set; }
        public byte labor_category { get; set; }
        public ResourceType output_resource_id { get; set; }
        public bool has_road_access { get; set; }
        public byte house_criminal_active { get; set; }
        public short damage_risk { get; set; }
        public short fire_risk { get; set; }
        public short fire_duration { get; set; }
        public byte fire_proof { get; set; } // cannot catch fire or collapse
        public byte house_figure_generation_delay { get; set; }
        public byte house_tax_coverage { get; set; }
        public byte house_pantheon_access { get; set; }
        public short formation_id { get; set; }
        public byte monthly_levy { get; set; }
        public int tax_income_or_storage { get; set; }
        public byte house_days_without_food { get; set; }
        public byte has_plague { get; set; }
        public sbyte desirability { get; set; }
        public byte is_deleted { get; set; }
        public byte is_adjacent_to_water { get; set; }
        public byte storage_id { get; set; }
        public Sentiment sentiment { get; set; } = new Sentiment();
        public byte show_on_problem_overlay { get; set; }
        public byte house_tavern_wine_access { get; set; }
        public byte house_tavern_meat_access { get; set; }
        public byte house_arena_gladiator { get; set; }
        public byte house_arena_lion { get; set; }
        public byte is_tourism_venue { get; set; }
        public byte tourism_disabled { get; set; }
        public byte tourism_income { get; set; }
        public byte tourism_income_this_year { get; set; }
        public byte variant { get; set; }
        public byte upgrade_level { get; set; }
        public byte strike_duration_days { get; set; }
        public byte sickness_level { get; set; }
        public byte sickness_duration { get; set; }
        public byte sickness_doctor_cure { get; set; }
        public byte fumigation_frame { get; set; }
        public byte fumigation_direction { get; set; }

        public override string ToString()
        {
            return $"t:{type}, s:{size}, {base.ToString()} ({data?.ToString() ?? ""}, Loads: {loads_stored})";
        }
    }
}
