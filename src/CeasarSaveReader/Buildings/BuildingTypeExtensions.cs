using CeasarSaveReader.Resources;

namespace CeasarSaveReader.Buildings
{
    public static class BuildingTypeExtensions
    {
        public static bool is_industry_type(this BuildingType type, ResourceType output_resource_id)
        {
            return output_resource_id > 0 ||
                type == BuildingType.NATIVE_CROPS ||
                type == BuildingType.SHIPYARD ||
                type == BuildingType.WHARF;
        }

        public static bool IsWorkshop(this BuildingType type)
        {
            return type >= BuildingType.WINE_WORKSHOP && type <= BuildingType.POTTERY_WORKSHOP;
        }
        public static bool IsHouse(this BuildingType type)
        {
            return type >= BuildingType.HOUSE_VACANT_LOT && type <= BuildingType.HOUSE_LUXURY_PALACE;
        }

        public static bool IsInsula(this BuildingType type)
        {
            return type >= BuildingType.HOUSE_SMALL_INSULA && type <= BuildingType.HOUSE_GRAND_INSULA;
        }

        public static bool IsFarm(this BuildingType type)
        {
            return type >= BuildingType.WHEAT_FARM && type <= BuildingType.PIG_FARM;
        }
        public static bool IsSmallTemple(this BuildingType type)
        {
            return type >= BuildingType.SMALL_TEMPLE_CERES && type <= BuildingType.SMALL_TEMPLE_VENUS;
        }

        public static bool building_monument_is_monument(this BuildingType type)
        {
            return Constants.MONUMENT_BUILDING_TYPES.Contains(type);
        }

        public static bool building_type_is_roadblock(this BuildingType type)
        {
            switch (type)
            {
                case BuildingType.ROADBLOCK:
                case BuildingType.GARDEN_WALL_GATE:
                case BuildingType.HEDGE_GATE_DARK:
                case BuildingType.HEDGE_GATE_LIGHT:
                case BuildingType.PALISADE_GATE:
                    return true;
                default:
                    return false;
            }
        }

        public static bool building_has_supplier_inventory(this BuildingType type)
        {
            return (type == BuildingType.MARKET ||
                type == BuildingType.MESS_HALL ||
                type == BuildingType.CARAVANSERAI ||
                type == BuildingType.SMALL_TEMPLE_CERES ||
                type == BuildingType.LARGE_TEMPLE_CERES ||
                type == BuildingType.SMALL_TEMPLE_VENUS ||
                type == BuildingType.LARGE_TEMPLE_VENUS ||
                type == BuildingType.TAVERN);
        }

        public static bool IsResourceDestination(this BuildingType type)
        {
            return type.IsWorkshop() ||
                type == BuildingType.GRANARY ||
                type == BuildingType.WAREHOUSE ||
                type == BuildingType.DOCK;
        }
    }
}
