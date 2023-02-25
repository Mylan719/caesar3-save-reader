namespace CeasarSaveReader.Figures.Model
{
    public static class FigureTypeStateExtensions
    {
        public static bool IsDelivery(this FigureType figureType)
            => figureType == FigureType.CART_PUSHER
            || figureType == FigureType.WAREHOUSEMAN
            || figureType == FigureType.DOCKER;
    }
}
