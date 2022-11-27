#define RESOURCE_MAX


namespace CeasarSaveReader.City
{
    public class Festival
    {
        public PlannedFestival planned = new PlannedFestival();
        public SelectedFestival selected = new SelectedFestival();
        public int small_cost;
        public int large_cost;
        public int grand_cost;
        public int grand_wine;
        public int not_enough_wine;

        public int months_since_festival;
        public int first_festival_effect_months;
        public int second_festival_effect_months;
    }
}
