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

        public virtual IReadOnlyList<TextPart> ToTextParts() => new List<TextPart>() { new TextPart(ToString(),0, true)};
    }

    public record TextPart(string Text, int Offset = 0, bool IsBold = false)
    {
        public override string ToString() => $"- {string.Join("", Enumerable.Range(0, Offset).Select(i => "\t"))}{Text}";
    }
}
