namespace CeasarSaveReader.Buildings
{
    public enum BuildingState : byte
    {
        UNUSED = 0,
        IN_USE = 1,
        UNDO = 2,
        CREATED = 3,
        RUBBLE = 4,
        DELETED_BY_GAME = 5, // used for earthquakes, fires, house mergers
        DELETED_BY_PLAYER = 6,
        MOTHBALLED = 7,
        ORIGINAL_BUFFER_SIZE = 128,
        TOURISM_BUFFER_SIZE = 134,
        VARIANTS_AND_UPGRADES = 136,
        STRIKES = 137,
        SICKNESS = 142,
        CURRENT_BUFFER_SIZE = 142
    }
}
