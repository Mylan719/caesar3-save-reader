namespace CeasarSaveReader.Buildings.Model
{
    public class Dock : BuildingData
    {
        public Dock()
        {
        }

        public short queued_docker_id { get; set; }
        public byte num_ships { get; set; }
        public sbyte orientation { get; set; }
        public short[] docker_ids { get; set; } = new short[3];
        public short trade_ship_id { get; set; }
        public byte has_accepted_route_ids { get; set; }
        public int accepted_route_ids { get; set; }
    }
}
