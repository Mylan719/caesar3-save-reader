namespace CeasarSaveReader.Buildings.Model
{
    public class Market : InventoryFetcherData
    {
        public short[] inventory { get; set; } = new short[8];
        public short pottery_demand { get; set; }
        public short furniture_demand { get; set; }
        public short oil_demand { get; set; }
        public short wine_demand { get; set; }
        public byte is_mess_hall { get; set; }
    }
}
