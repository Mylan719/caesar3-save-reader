using CeasarSaveReader.Map;

namespace CeasarSaveReader.Scenario.Model
{
    public record Map
    {
        public Size Size { get; }
        public GridOffset GridStart { get; }
        public int BorderSize { get; }

        public Map(Size size, GridOffset gridStart, int borderSize)
        {
            Size = size;
            GridStart = gridStart;
            BorderSize = borderSize;
        }
    }
}
