using CeasarSaveReader.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Scenario.Model
{
    public class ScenarioData
    {
        public string scenario_name { get; set; }

        public int start_year { get; set; }
        public int climate { get; set; }
        public int player_rank { get; set; }

        public int initial_funds { get; set; }
        public int rescue_loan { get; set; }

        public int rome_supplies_wheat { get; set; }
        public int image_id { get; set; }
        public string brief_description { get; set; }
        public string briefing { get; set; }
        public int enemy_id { get; set; }
        public int is_open_play { get; set; }
        public int open_play_scenario_id { get; set; }

        public ScenarioWinCriteria win_criteria { get; set; } = new ScenarioWinCriteria();

        public Empire empire { get; set; } = new Empire();


        public Request[] requests { get; set; } = new Request[Constants.MAX_REQUESTS];
        public DemandChange[] demand_changes { get; set; } = new DemandChange[Constants.MAX_DEMAND_CHANGES];
        public PriceChange[] price_changes { get; set; } = new PriceChange[Constants.MAX_DEMAND_CHANGES];
        public Invasion[] invasions { get; set; } = new Invasion[Constants.MAX_INVASIONS];
        public Earthquake earthquake { get; set; } = new Earthquake();
        public EmperorChange emperor_change { get; set; } = new EmperorChange();
        public GladiatorRevoult gladiator_revoult { get; set; } = new GladiatorRevoult();
        public RandomEvents random_events { get; set; } = new RandomEvents();
        public Map map { get; set; } 

        public bool flotsam_enabled { get; set; }
        public MapPoint entry_point { get; set; }
        public MapPoint exit_point { get; set; }
        public MapPoint river_entry_point { get; set; }
        public MapPoint river_exit_point { get; set; }
        public MapPoint earthquake_point { get; set; }
        public MapPoint[] herd_points { get; set; } = new MapPoint[Constants.MAX_HERD_POINTS];
        public MapPoint[] fishing_points { get; set; } = new MapPoint[Constants.MAX_FISH_POINTS];
        public MapPoint[] invasion_points { get; set; } = new MapPoint[Constants.MAX_INVASION_POINTS];

        public short[] allowed_buildings { get; set; } = new short[Constants.MAX_ALLOWED_BUILDINGS];

        public NativeImage native_images { get; set; } = new NativeImage();
        public Settings settings { get; set; } = new Settings();
        public bool is_saved { get; set; }
    }
}
