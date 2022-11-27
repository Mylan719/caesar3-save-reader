namespace CeasarSaveReader.Buildings.Model
{
    public class Industry : BuildingData
    {
        public short progress { get; set; }
        public byte blessing_days_left { get; set; }
        public byte curse_days_left { get; set; }
        public byte has_raw_materials { get; set; }
        public byte has_fish { get; set; }
        public byte is_stockpiling { get; set; }
        public byte orientation { get; set; }
        public short fishing_boat_id { get; set; }
        public byte age_months { get; set; }
        public byte average_production_per_month { get; set; }
        public short production_current_month { get; set; }
    }
}
