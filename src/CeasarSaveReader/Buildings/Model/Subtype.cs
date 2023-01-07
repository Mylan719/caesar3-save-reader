namespace CeasarSaveReader.Buildings.Model
{
    public class Subtype
    {
        private short unionField;
        public short house_level { get => unionField; set => unionField = value; }
        public short warehouse_resource_id { get => unionField; set => unionField = value; }
        public WorkshopType workshop_type { get => (WorkshopType)unionField; set => unionField = (short)value; }
        public short orientation { get => unionField; set => unionField = value; }
        public short fort_figure_type { get => unionField; set => unionField = value; }
        public short native_meeting_center_id { get => unionField; set => unionField = value; }
        public short market_goods { get => unionField; set => unionField = value; }
        public short barracks_priority { get => unionField; set => unionField = value; }
    }
}
