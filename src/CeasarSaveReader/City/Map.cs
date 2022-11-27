#define RESOURCE_MAX


using CeasarSaveReader.Map;

namespace CeasarSaveReader.City
{
    public class Map
    {
        public MapTile entry_point = new MapTile();
        public MapTile exit_point = new MapTile();
        public MapTile entry_flag = new MapTile();
        public MapTile exit_flag = new MapTile();
        public LargestRoadNetworks[] largest_road_networks = new LargestRoadNetworks[10]; //10

        public Map()
        {
            for (int i = 0; i < 10; i++)
            {
                largest_road_networks[i] = new LargestRoadNetworks();
            }
        }
    }
}
