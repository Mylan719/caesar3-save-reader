namespace CeasarSaveReader.Buildings
{
    public class Constants
    {
        public const int SAVE_GAME_ROADBLOCK_DATA_MOVED_FROM_SUBTYPE = 0x86;
        public const int SAVE_GAME_CARAVANSERAI_OFFSET_FIX = 0x88;
        public const int BUILDING_STATE_ORIGINAL_BUFFER_SIZE = 128;
        public const int BUILDING_STATE_TOURISM_BUFFER_SIZE = 134;
        public const int BUILDING_STATE_VARIANTS_AND_UPGRADES = 136;
        public const int BUILDING_STATE_STRIKES = 137;
        public const int BUILDING_STATE_SICKNESS = 142;
        public const int BUILDING_STATE_CURRENT_BUFFER_SIZE = 142;

        public static BuildingType[] MONUMENT_BUILDING_TYPES = new[]
        {
            BuildingType.ORACLE,
            BuildingType.LARGE_TEMPLE_CERES,
            BuildingType.LARGE_TEMPLE_NEPTUNE,
            BuildingType.LARGE_TEMPLE_MERCURY,
            BuildingType.LARGE_TEMPLE_MARS,
            BuildingType.LARGE_TEMPLE_VENUS,
            BuildingType.GRAND_TEMPLE_CERES,
            BuildingType.GRAND_TEMPLE_NEPTUNE,
            BuildingType.GRAND_TEMPLE_MERCURY,
            BuildingType.GRAND_TEMPLE_MARS,
            BuildingType.GRAND_TEMPLE_VENUS,
            BuildingType.PANTHEON,
            BuildingType.LIGHTHOUSE,
            BuildingType.COLOSSEUM,
            BuildingType.HIPPODROME,
            BuildingType.NYMPHAEUM,
            BuildingType.LARGE_MAUSOLEUM,
            BuildingType.SMALL_MAUSOLEUM,
            BuildingType.CARAVANSERAI
        };
    }
}
