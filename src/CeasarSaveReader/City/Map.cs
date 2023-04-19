#define RESOURCE_MAX


using CeasarSaveReader.Map;

namespace CeasarSaveReader.City
{
    public record Map
    {
        public MapTile EntryPoint { get; }
        public MapTile ExitPoint { get; }
        //TODO: look into why the flags are unused
        public LargestRoadNetwork[] LargestRoadNetworks { get; }

        public Map(
            MapTile EntryPoint,
            MapTile ExitPoint,
            LargestRoadNetwork[] LargestRoadNetworks)
        {
            this.EntryPoint = EntryPoint;
            this.ExitPoint = ExitPoint;
            this.LargestRoadNetworks = LargestRoadNetworks;
        }
    }
}