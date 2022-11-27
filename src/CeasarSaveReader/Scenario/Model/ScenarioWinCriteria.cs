namespace CeasarSaveReader.Scenario.Model
{
    public class ScenarioWinCriteria
    {
        public WinCriteria population { get; set; } = new WinCriteria();
        public WinCriteria culture { get; set; } = new WinCriteria();
        public WinCriteria prosperity { get; set; } = new WinCriteria();
        public WinCriteria peace { get; set; } = new WinCriteria();
        public WinCriteria favor { get; set; } = new WinCriteria();
        public TimeLimit time_limit { get; set; } = new TimeLimit();
        public SurvivalTime survival_time { get; set; } = new SurvivalTime();

        public int milestone25_year { get; set; }
        public int milestone50_year { get; set; }
        public int milestone75_year { get; set; }
    } //scenario_win_criteria
}
