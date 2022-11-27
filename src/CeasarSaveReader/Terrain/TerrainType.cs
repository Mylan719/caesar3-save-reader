namespace CeasarSaveReader.Terrain
{
    public enum TerrainType
    {
        TREE = 1,
        ROCK = 2,
        WATER = 4,
        BUILDING = 8,
        SCRUB = 0x10,
        GARDEN = 0x20,
        ROAD = 0x40,
        RESERVOIR_RANGE = 0x80,
        AQUEDUCT = 0x100,
        ELEVATION = 0x200,
        ACCESS_RAMP = 0x400,
        MEADOW = 0x800,
        RUBBLE = 0x1000,
        FOUNTAIN_RANGE = 0x2000,
        WALL = 0x4000,
        GATEHOUSE = 0x8000,
        OUTSIDE_MAP = TREE | WATER
    }
}
