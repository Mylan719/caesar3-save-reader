using CeasarSaveReader.Buildings;
using CeasarSaveReader.Figures.Model;
using CeasarSaveReader.Map;
using CeasarSaveReader.Terrain;

namespace CeasarSaveReader.Tools
{
    public class DebugWriter
    {
        public static void PrintGrid(Grid<bool> grid)
        {
            grid.ForTile((coords, tile) =>
            {
                if (tile)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write(".");
                }
            },
            y => Console.WriteLine());
        }
        public static void PrintGrid(Grid<int> grid)
        {
            grid.ForTile((coords, tile) =>
            {
                if (tile > 0)
                    Console.Write($"{tile:00} ");
                else
                    Console.Write(".. ");
            },
            y => Console.WriteLine());
        }

        public static void PrintBuildings(Grid<BuildingType> buildings)
        {
            buildings.ForTile((coords, building) =>
            {
                if (building >= BuildingType.HOUSE_VACANT_LOT && building <= BuildingType.HOUSE_LUXURY_PALACE)
                {
                    Console.Write("H");
                }
                else if (building >= BuildingType.WHEAT_FARM && building <= BuildingType.PIG_FARM)
                {
                    Console.Write("F");
                }
                else if (building >= BuildingType.MARBLE_QUARRY && building <= BuildingType.POTTERY_WORKSHOP)
                {
                    Console.Write("W");
                }
                else if (building == BuildingType.ROAD)
                {
                    Console.Write("=");
                }
                else if (building == BuildingType.RESERVOIR)
                {
                    Console.Write("~");
                }
                else if (building == BuildingType.FOUNTAIN || building == BuildingType.WELL)
                {
                    Console.Write("@");
                }
                else if (building != BuildingType.NONE)
                {
                    Console.Write("B");
                }
                else
                {
                    Console.Write(".");
                }
            },
            y => Console.WriteLine());
        }

        public static void PrintFigures(Grid<FigureType> figures)
        {
            figures.ForTile((coords, figure) =>
            {
                if (figure == FigureType.ACTOR)
                {
                    Console.Write("A");
                }
                else if (figure == FigureType.BARBER)
                {
                    Console.Write("b");
                }
                else if (figure == FigureType.BATHHOUSE_WORKER)
                {
                    Console.Write("B");
                }
                else if (figure == FigureType.CART_PUSHER)
                {
                    Console.Write("C");
                }
                else if (figure == FigureType.CART_PUSHER)
                {
                    Console.Write("C");
                }
                else if (figure == FigureType.DELIVERY_BOY)
                {
                    Console.Write("*");
                }
                else if (figure == FigureType.DOCKER)
                {
                    Console.Write("D");
                }
                else if (figure == FigureType.DOCTOR)
                {
                    Console.Write("d");
                }
                else if (figure == FigureType.ENGINEER)
                {
                    Console.Write("E");
                }
                else if (figure == FigureType.PREFECT)
                {
                    Console.Write("P");
                }
                else if (figure == FigureType.PRIEST)
                {
                    Console.Write("p");
                }
                else if (figure == FigureType.MARKET_SUPPLIER || figure == FigureType.MARKET_TRADER)
                {
                    Console.Write("p");
                }
                else if (figure == FigureType.FLOTSAM)
                {
                    Console.Write("~");
                }
                else if (figure == FigureType.ENEMY43_SPEAR) //hack to mark road
                {
                    Console.Write("=");
                }
                else
                {
                    Console.Write(".");
                }
            },
            y => Console.WriteLine());
        }

        public static void PrintTerrain(Grid<TerrainType> terrainGrid)
        {
            terrainGrid.ForTile((coords, terrain) =>
            {
                char symbol;
                if ((terrain & TerrainType.OUTSIDE_MAP) == TerrainType.OUTSIDE_MAP)
                {
                    symbol = '\0';
                }
                else if ((terrain & TerrainType.TREE) > 0)
                {
                    symbol = 'Y';
                }
                else if ((terrain & TerrainType.ROCK) > 0)
                {
                    symbol = 'O';
                }
                else if (terrain.IsWater())
                {
                    symbol = '~';
                }
                else if ((terrain & TerrainType.BUILDING) > 0)
                {
                    symbol = 'B';
                }
                else if ((terrain & TerrainType.SCRUB) > 0)
                {
                    symbol = 'v';
                }
                else if ((terrain & TerrainType.GARDEN) > 0)
                {
                    symbol = 'z';
                }
                else if ((terrain & TerrainType.ROAD) > 0)
                {
                    symbol = '=';
                }
                else if ((terrain & TerrainType.AQUEDUCT) > 0)
                {
                    symbol = '|';
                }
                else if ((terrain & TerrainType.ELEVATION) > 0)
                {
                    symbol = '/';
                }
                else if ((terrain & TerrainType.ACCESS_RAMP) > 0)
                {
                    symbol = '\\';
                }
                else if ((terrain & TerrainType.WALL) > 0)
                {
                    symbol = 'w';
                }
                else if ((terrain & TerrainType.GATEHOUSE) > 0)
                {
                    symbol = 'W';
                }
                else if ((terrain & TerrainType.MEADOW) > 0)
                {
                    symbol = '_';
                }
                else if ((terrain & TerrainType.RUBBLE) > 0)
                {
                    symbol = ';';
                }
                else
                {
                    symbol = '.';
                }
                if (symbol > 0)
                {
                    Console.Write(symbol);
                }
            }, 
            y => Console.WriteLine());
        }
    }
}
