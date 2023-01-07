using CeasarSaveReader.Resources;

namespace CeasarSaveReader.City
{
    public class Resource
    {
        public short[] space_in_warehouses = new short[(int)ResourceType.MAX];
        public short[] stored_in_warehouses = new short[(int)ResourceType.MAX];
        public int[] space_in_workshops = new int[6];
        public int[] stored_in_workshops = new int[6];
        public short[] trade_status = new short[(int)ResourceType.MAX];
        public short[] export_status_before_stockpiling = new short[(int)ResourceType.MAX];
        public short[] import_over = new short[(int)ResourceType.MAX];
        public short[] export_over = new short[(int)ResourceType.MAX];
        public int[] stockpiled = new int[(int)ResourceType.MAX];
        public short[] mothballed = new short[(int)ResourceType.MAX];
        public int wine_types_available;
        public int food_types_available;
        public int food_types_eaten;
        public int[] granary_food_stored = new int[(int)ResourceType.MAX_FOOD];
        public int granary_total_stored;
        public int food_supply_months;
        public int food_needed_per_month;
        public int food_consumed_last_month;
        public int food_produced_last_month;
        public int food_produced_this_month;
        public Granaries granaries = new Granaries();
        public short last_used_warehouse;
    }
}
