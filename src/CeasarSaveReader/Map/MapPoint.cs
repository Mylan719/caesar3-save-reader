namespace CeasarSaveReader.Map
{
    public record MapPoint
    {
        public MapPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
