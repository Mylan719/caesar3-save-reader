namespace CeasarSaveReader.Scenario.Model
{
    public class PriceChange
    {
        public int year { get; set; }
        public int month { get; set; }
        public int resource { get; set; }
        public int amount { get; set; }
        public int is_rise { get; set; }
    } //price_change_t
}
