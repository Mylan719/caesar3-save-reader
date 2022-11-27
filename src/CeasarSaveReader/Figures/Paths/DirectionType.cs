namespace CeasarSaveReader.Figures.Paths
{
    public enum DirectionType : byte
    {
        TOP = 0,
        TOP_RIGHT = 1,
        RIGHT = 2,
        BOTTOM_RIGHT = 3,
        BOTTOM = 4,
        BOTTOM_LEFT = 5,
        LEFT = 6,
        TOP_LEFT = 7,
        NONE = 8,
        FIGURE_AT_DESTINATION = 8,
        FIGURE_REROUTE = 9,
        FIGURE_LOST = 10,
        FIGURE_ATTACK = 11,
    }
}
