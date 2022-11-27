#define RESOURCE_MAX


using CeasarSaveReader.City.LabourData;

namespace CeasarSaveReader.City
{
    public class Labor
    {
        public int wages;
        public int wages_rome;
        public int months_since_last_wage_change;
        public int workers_available;
        public int workers_employed;
        public int workers_unemployed;
        public int workers_needed;
        public int unemployment_percentage;
        public int unemployment_percentage_for_senate;
        public LaborCategoryData[] categories = new LaborCategoryData[10]; //10
    }
}
