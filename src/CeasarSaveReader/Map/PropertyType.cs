using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Map
{
    public static class PropertyExtensions
    {
        public static int GetBuildingSize(this PropertyType tile)
        {
            switch (tile & PropertyType.BIT_SIZES)
            {
                case PropertyType.BIT_SIZE2: return 2;
                case PropertyType.BIT_SIZE3: return 3;
                case PropertyType.BIT_SIZE4: return 4;
                case PropertyType.BIT_SIZE5: return 5;
                case PropertyType.BIT_SIZE7: return 7;
                default: return 1;
            }
        }
    }
    public enum PropertyType
    {
        BIT_SIZE1 = 0x00,
        BIT_SIZE2 = 0x01,
        BIT_SIZE3 = 0x02,
        BIT_SIZE4 = 0x04,
        BIT_SIZE5 = 0x08,
        BIT_SIZE7 = 0x0f,
        BIT_SIZES = 0x0f,
        BIT_NO_SIZES = 0xf0,
        BIT_CONSTRUCTION = 0x10,
        BIT_NO_CONSTRUCTION = 0xef,
        BIT_ALTERNATE_TERRAIN = 0x20,
        BIT_DELETED = 0x40,
        BIT_NO_DELETED = 0xbf,
        BIT_PLAZA_OR_EARTHQUAKE = 0x80,
        BIT_NO_PLAZA = 0x7f,
        BIT_NO_CONSTRUCTION_AND_DELETED = 0xaf,
        EDGE_MASK_X = 0x7,
        EDGE_MASK_Y = 0x38,
        EDGE_MASK_XY = 0x3f,
        EDGE_LEFTMOST_TILE = 0x40,
        EDGE_NO_LEFTMOST_TILE = 0xbf,
        EDGE_NATIVE_LAND = 0x80,
        EDGE_NO_NATIVE_LAND = 0x7f,
    }
}
