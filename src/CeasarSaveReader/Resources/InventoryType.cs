#define RESOURCE_MAX


namespace CeasarSaveReader.Resources
{
    public enum InventoryType
    {
        NONE = -1,
        WHEAT = 0,
        VEGETABLES = 1,
        FRUIT = 2,
        MEAT = 3,
        WINE = 4,
        OIL = 5,
        FURNITURE = 6,
        POTTERY = 7,
        // helper constants
        MIN_FOOD = 0,
        MAX_FOOD = 4,
        MIN_GOOD = 4,
        MAX_GOOD = 8,
        MAX = 8,
        // inventory flags
        FLAG_NONE = 0,
        FLAG_ALL_FOODS = 0x0f,
        FLAG_ALL_GOODS = 0xf0,
        FLAG_ALL = 0xff
    }
}
