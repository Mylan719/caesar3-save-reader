namespace CeasarSaveReader.Scenario.Model
{
    public class Settings
    { // used to be stored in the settings file
        public int campaign_rank { get; set; }
        public int campaign_mission { get; set; }
        public int is_custom { get; set; }
        public int starting_favor { get; set; }
        public int starting_personal_savings { get; set; }
        public string player_name { get; set; }
        /** Temp storage for carrying over player name to next campaign mission */
        public string campaign_player_name { get; set; }
    } //settings
}
