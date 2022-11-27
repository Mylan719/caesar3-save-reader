namespace CeasarSaveReader.Map
{
    public static class GridExtensions
    {
        public static Grid<TResult> ForGrid<TTile, TResult>(this Grid<TTile> grid, Func<GridOffset, TTile, TResult> selector)
            where TTile : struct
            where TResult : struct
        {
            var resultGrid = new Grid<TResult>(grid.Start, grid.Size);

            for (int y = 0; y < grid.Size.Height; y++)
            {
                for (int x = 0; x < grid.Size.Width; x++)
                {
                    var offset = new GridOffset(x, y);
                    var tile = grid[offset];

                    resultGrid[offset] = selector(offset, tile);
                }
            }

            return resultGrid;
        }

        public static IEnumerable<TResult> ForTile<TTile, TResult>(this Grid<TTile> grid, Func<GridOffset, TTile, TResult> selector)
            where TTile : struct
        {
            for (int y = 0; y < grid.Size.Height; y++)
            {
                for (int x = 0; x < grid.Size.Width; x++)
                {
                    var offset = new GridOffset(x, y);
                    var tile = grid[offset];

                    yield return selector(offset, tile);
                }
            }
        }

        public static void ForTile<TTile>(this Grid<TTile> grid, Action<GridOffset, TTile> tileAction, Action<int>? rowAction = null)
            where TTile : struct
        {
            for (int y = 0; y < grid.Size.Height; y++)
            {
                for (int x = 0; x < grid.Size.Width; x++)
                {
                    var offset = new GridOffset(x, y);
                    var tile = grid[offset];

                    tileAction(offset, tile);
                }
                rowAction?.Invoke(y);
            }
        }
    }
}
