namespace CeasarSaveReader.Scenario.Model
{
    public class DemandChange
    {
        public int year { get; set; }
        public int month { get; set; }
        public int resource { get; set; }
        public int route_id { get; set; }
        public int is_rise { get; set; }
    } //demand_change_t
}
