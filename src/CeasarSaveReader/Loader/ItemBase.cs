using CeasarSaveReader.Map;

namespace CeasarSaveReader.Loader
{
    public class ItemBase<TState>
        where TState : Enum
    {
        public int id { get; set; }
        public TState state { get; set; }
        public GridOffset Coordinates { get; set; }
        public GridOffset GlobalCoordinates { get; set; }

        public override string ToString()
        {
            return $"{state} ({Coordinates})";
        }
    }
}
