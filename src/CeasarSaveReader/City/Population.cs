#define RESOURCE_MAX


namespace CeasarSaveReader.City
{
    public class Population
    {
        public int population;
        public int population_last_year;
        public int school_age;
        public int academy_age;
        public int working_age;

        public PopulationMonthly monthly = new PopulationMonthly();

        public short[] at_age = new short[100]; //100
        public int[] at_level = new int[20]; //20

        public int yearly_update_requested;
        public int yearly_births;
        public int yearly_deaths;
        public int lost_removal;
        public int lost_homeless;
        public int lost_troop_request;
        public int last_change;
        public int total_all_years;
        public int total_years;
        public int average_per_year;
        public int highest_ever;
        public int total_capacity;
        public int room_in_houses;

        public int people_in_tents;
        public int people_in_tents_shacks;
        public int people_in_large_insula_and_above;
        public int people_in_villas_palaces;
        public int percentage_plebs;

        public int last_used_house_add;
        public int last_used_house_remove;
        public int graph_order;
    }
}
