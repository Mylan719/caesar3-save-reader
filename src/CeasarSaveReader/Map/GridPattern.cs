using System.Reflection;

namespace CeasarSaveReader.Map
{
    public static class GridPatternHelper
    {
        public static GridPattern<bool> CreateFromPicture(string picture)
        {
            if (picture.Length != 9) throw new ArgumentException("Picture must be inicialized with 9 characters.");

            var tiles = picture.Select(p => p == 'X').ToArray();

            return new GridPattern<bool>(tiles);
        }
    }

    public record GridPattern<TTile>
        where TTile : struct
    {
        private readonly TTile[] tiles;

        public TTile Left { get; }
        public TTile Right { get; }
        public TTile Up { get; }
        public TTile Down { get; }

        public TTile UpperLeft { get; }
        public TTile UpperRight { get; }
        public TTile LowerLeft { get; }
        public TTile LowerRight { get; }

        public TTile Middle { get; }

        public GridPattern(TTile[] tiles)
        {
            if (tiles.Length != 9) throw new ArgumentException("Pattern must be inicialized with 9 elements.");

            Left = tiles[3];
            Right = tiles[5];
            Up = tiles[1];
            Down = tiles[7];

            UpperLeft = tiles[0];
            UpperRight = tiles[2];
            LowerLeft = tiles[6];
            LowerRight = tiles[8];

            Middle = tiles[4];
            this.tiles = tiles;
        }

        public TTile[] GetTiles() => tiles;

        /// <summary>
        /// Provides emediate neighburs of the middle tile in streight lines (As rook in chess). 
        /// </summary>
        /// <returns>Array of neighburs in clockwise order.</returns>
        public TTile[] GetDirectNeighburs() => new[] { Up, Right, Down, Left };

        /// <summary>
        /// Provides emediate neighburs of the middle tile in diagonal lines (As bishop in chess). 
        /// </summary>
        /// <returns>Array of neighburs in clockwise order.</returns>
        public TTile[] GetCornerNeighburs() => new[] { UpperLeft, UpperRight, LowerRight, LowerLeft };

        /// <summary>
        /// Provides emediate neighburs of the middle tile. 
        /// </summary>
        /// <returns>Array of neighburs in clockwise order.</returns>
        public TTile[] GetAllNeighburs() => new[] { UpperLeft, Up, UpperRight, Right, LowerRight, Down, LowerLeft, Left };
    }
}
