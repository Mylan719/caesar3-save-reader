#define RESOURCE_MAX


namespace CeasarSaveReader.City
{
    public class Ratings
    {
        public int culture;
        public int prosperity;
        public int peace;
        public int favor;
        public CulturePoints culture_points = new CulturePoints();
        public int prosperity_treasury_last_year;
        public int prosperity_max;
        public int peace_destroyed_buildings;
        public int peace_years_of_peace;
        public int peace_num_criminals;
        public int peace_num_rioters;
        public int peace_riot_cause;
        public int favor_salary_penalty;
        public int favor_milestone_penalty;
        public int favor_ignored_request_penalty;
        public int favor_last_year;
        public int favor_change; // 0 = dropping, 1 = stalling, 2 = rising

        public int selected;
        public int culture_explanation;
        public int prosperity_explanation;
        public int peace_explanation;
        public int favor_explanation;
    }
}
