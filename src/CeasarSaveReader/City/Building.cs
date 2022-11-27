#define RESOURCE_MAX


using CeasarSaveReader.Map;

namespace CeasarSaveReader.City
{
    public class Building
    {
        public short senate_placed;
        public byte senate_x;
        public byte senate_y;
        public short senate_grid_offset;
        public int senate_building_id;
        public int hippodrome_placed;
        public sbyte barracks_x;
        public sbyte barracks_y;
        public short barracks_grid_offset;
        public int barracks_building_id;
        public int barracks_placed;
        public sbyte distribution_center_x;
        public sbyte distribution_center_y;
        public short distribution_center_grid_offset;
        public int distribution_center_building_id;
        public int distribution_center_placed;
        public int trade_center_building_id;
        public sbyte triumphal_arches_available;
        public sbyte triumphal_arches_placed;
        public short working_wharfs;
        public int caravanserai_building_id;
        public int shipyard_boats_requested;
        public short working_docks;
        public short[] working_dock_ids = new short[10]; //10
        public int mission_post_operational;
        public MapPoint main_native_meeting = new MapPoint(0, 0);
        public sbyte unknown_value;
        public int mess_hall_building_id;
        public int num_striking_industries;
        public ushort months_since_last_destroyed_iron_mine;
        public ushort months_since_last_flooded_clay_pit;
    }
}
