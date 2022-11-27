#define RESOURCE_MAX


namespace CeasarSaveReader.City
{
    public class Taxes
    {
        public int taxed_plebs;
        public int taxed_patricians;
        public int untaxed_plebs;
        public int untaxed_patricians;
        public int percentage_taxed_plebs;
        public int percentage_taxed_patricians;
        public int percentage_taxed_people;
        public YearlyTaxes yearly = new YearlyTaxes();
        public MonthlyTaxes monthly = new MonthlyTaxes();
    }
}
