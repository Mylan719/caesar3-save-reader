namespace CeasarSaveReader.Buildings.Model
{
    public class Monument : InventoryFetcherData
    {
        public short[] resources_needed { get; set; } = new short[16];
        public int upgrades { get; set; }
        public short progress { get; set; }
        public short phase { get; set; }
        public short secondary_frame { get; set; }
    }
}
