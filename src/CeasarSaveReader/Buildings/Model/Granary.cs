namespace CeasarSaveReader.Buildings.Model
{
    public class Granary : BuildingData
    {
        public short[] resource_stored { get; set; } = new short[16];
    }
}
