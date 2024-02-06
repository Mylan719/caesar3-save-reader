namespace CeasarSaveReader.Map
{
    public enum EdgeType : byte
    {
        MASK_X = 0x7,
        MASK_Y = 0x38,
        MASK_XY = 0x3f,
        LEFTMOST_TILE = 0x40,
        NO_LEFTMOST_TILE = 0xbf,
        NATIVE_LAND = 0x80,
        NO_NATIVE_LAND = 0x7f,
    }

    public static class EdgeTypeExtensions
    {
        public static bool IsNativeLand(this EdgeType tile)
        {
            return (tile & EdgeType.NATIVE_LAND) > 0;
        }
    }
}
