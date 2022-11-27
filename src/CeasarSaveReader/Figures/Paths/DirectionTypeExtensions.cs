namespace CeasarSaveReader.Figures.Paths
{
    public static class DirectionTypeExtensions
    {
        public static (int, int) GetDirectionXY(this DirectionType direction)
        {
            switch (direction)
            {
                case DirectionType.TOP:
                    return (0, 1);
                case DirectionType.TOP_RIGHT:
                    return (1, 1);
                case DirectionType.RIGHT:
                    return (1, 0);
                case DirectionType.BOTTOM_RIGHT:
                    return (1, -1);
                case DirectionType.BOTTOM:
                    return (0, -1);
                case DirectionType.BOTTOM_LEFT:
                    return (-1, -1);
                case DirectionType.LEFT:
                    return (-1, 0);
                case DirectionType.TOP_LEFT:
                    return (-1, 1);
                default:
                    return (0, 0);
            }
        }
    }
}
