using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Terrain
{
    public static class Extensions
    {
        public static bool IsCityBuildingOrRoad(this TerrainType terrain) => IsCityBuilding(terrain) || IsRoad(terrain);
        public static bool IsCityBuilding(this TerrainType terrain)
        {
            return (terrain & TerrainType.BUILDING) > 0 && (terrain & TerrainType.GATEHOUSE) == 0;
        }

        public static bool IsRoad(this TerrainType terrain)
        {
            return (terrain & TerrainType.ROAD) > 0;
        }

        public static bool IsWater(this TerrainType terrain) => (terrain & TerrainType.WATER) != 0;

        public static bool IsNonNavigable(this TerrainType terrain)
        {
            if(IsRoad(terrain)) { return false; } //Some roads can be inside of otherwise nonnavigable structures (aquaduct, gate,...) 
            return
               (terrain & TerrainType.SCRUB) != 0 ||
               (terrain & TerrainType.TREE) != 0 ||
               (terrain & TerrainType.ROCK) != 0 ||
               (terrain & TerrainType.BUILDING) != 0 ||
               (terrain & TerrainType.AQUEDUCT) != 0 ||
               (terrain & TerrainType.ACCESS_RAMP) != 0 ||
               (terrain & TerrainType.RUBBLE) != 0 ||
               (terrain & TerrainType.WATER) != 0 ||
               (terrain & TerrainType.WALL) != 0;
        }

        public static bool IsLand(this TerrainType terrain)
        {
            return
                (terrain & TerrainType.TREE) == 0 &&
                (terrain & TerrainType.ROCK) == 0 &&
                (terrain & TerrainType.WATER) == 0 &&
                (terrain & TerrainType.BUILDING) == 0 &&
                (terrain & TerrainType.ROAD) == 0 &&
                (terrain & TerrainType.AQUEDUCT) == 0 &&
                (terrain & TerrainType.ACCESS_RAMP) == 0 &&
                (terrain & TerrainType.MEADOW) == 0 &&
                (terrain & TerrainType.RUBBLE) == 0 &&
                (terrain & TerrainType.WALL) == 0 &&
                (terrain & TerrainType.SCRUB) == 0 &&
                (terrain & TerrainType.GARDEN) == 0 &&
                (terrain & TerrainType.GATEHOUSE) == 0;
        }
    }
}
