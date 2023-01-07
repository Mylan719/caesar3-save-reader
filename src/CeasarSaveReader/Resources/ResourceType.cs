#define RESOURCE_MAX


namespace CeasarSaveReader.Resources
{
    public enum ResourceType : byte
    {
        NONE = 0,
        WHEAT = 1,
        VEGETABLES = 2,
        FRUIT = 3,
        OLIVES = 4,
        VINES = 5,
        MEAT = 6,
        WINE = 7,
        OIL = 8,
        IRON = 9,
        TIMBER = 10,
        CLAY = 11,
        MARBLE = 12,
        WEAPONS = 13,
        FURNITURE = 14,
        POTTERY = 15,
        DENARII = 16,
        TROOPS = 17,
        // helper constants
        MIN = 1,
        MAX = 16,
        MIN_FOOD = 1,
        MAX_FOOD = 7,
        MIN_RAW = 9,
        MAX_RAW = 13
    }
}
