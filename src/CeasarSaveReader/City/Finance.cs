#define RESOURCE_MAX


using CeasarSaveReader.City.Finances;

namespace CeasarSaveReader.City
{
    public class Finance
    {
        public int treasury;
        public int tax_percentage;
        public int estimated_tax_income;
        public int estimated_wages;
        public FinanceOverview last_year = new();
        public FinanceOverview this_year = new();
        public int interest_so_far;
        public int salary_so_far;
        public int wages_so_far;
        public int levies_so_far;
        public short stolen_this_year;
        public short stolen_last_year;
        public int cheated_money;
        public int tribute_not_paid_last_year;
        public int tribute_not_paid_total_years;
        public int wage_rate_paid_this_year;
        public int wage_rate_paid_last_year;
        public int tourism_rating;
        public int tourism_last_month;
        public int tourism_lowest_factor;
        public int tourism_last_year;
        public short tourism_this_year;
        public short tourist_spawn_delay;
    }
}
