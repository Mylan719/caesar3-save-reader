using CeasarSaveReader.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Map
{
    public record Grid<TTile>
        where TTile : struct
    {
        public TTile[] Tiles { get; }
        public GridOffset Start { get; }
        public Size Size { get; }

        public Grid(GridOffset start, Size size)
        {
            Start = start;
            Size = size;
            Tiles = new TTile[GridOffset.GRID_SIZE * GridOffset.GRID_SIZE];
        }

        public bool Exists(GridOffset coordinates)
        {
            return coordinates.Value > 0 && coordinates.X < Size.Width && coordinates.Y < Size.Height;
        }

        public bool Is(GridOffset coordinates, Predicate<TTile> predicate)
        {
            return Exists(coordinates) && predicate(this[coordinates]);
        }

        public IEnumerable<GridTile<TTile>> GetNeighburs(GridOffset coordinates)
        {
            if (Exists(coordinates.Up())) { yield return new GridTile<TTile>(this[coordinates.Up()], coordinates.Up()); }
            if (Exists(coordinates.Down())) { yield return new GridTile<TTile>(this[coordinates.Down()], coordinates.Down()); }
            if (Exists(coordinates.Left())) { yield return new GridTile<TTile>(this[coordinates.Left()], coordinates.Left()); }
            if (Exists(coordinates.Right())) { yield return new GridTile<TTile>(this[coordinates.Right()], coordinates.Right()); }
        }

        public GridPattern<TTile> GetPattern(GridOffset coordinates, TTile defaultValue)
        {
            var tiles = coordinates.GetPattern()
                .Select(p=> Exists(p) ? this[p] : defaultValue)
                .ToArray();

            return new GridPattern<TTile>(tiles);
        }

        public TTile this[GridOffset coordinates]
        {
            get => Tiles[Start.Value + coordinates.Value];
            set => Tiles[Start.Value + coordinates.Value] = value;
        }
    }
}
