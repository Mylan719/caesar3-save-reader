namespace CeasarSaveReader.Map
{
    public struct Size
    {
        public Size(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; }
        public int Width { get; }
    }
}
