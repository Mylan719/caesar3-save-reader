namespace CeasarSaveReader.Map
{
    public record GridTile<TTile>
        where TTile : struct
    {
        public TTile Tile { get; }
        public GridOffset Coords { get; }

        public GridTile(TTile tile, GridOffset coords)
        {
            Tile = tile;
            Coords = coords;
        }
    }
}
