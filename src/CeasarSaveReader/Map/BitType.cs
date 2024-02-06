using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Map
{
    public enum BitType : byte
    {
        SIZE1 = 0x00,
        SIZE2 = 0x01,
        SIZE3 = 0x02,
        SIZE4 = 0x04,
        SIZE5 = 0x08,
        SIZE7 = 0x0f,
        SIZES = 0x0f,
        NO_SIZES = 0xf0,
        CONSTRUCTION = 0x10,
        NO_CONSTRUCTION = 0xef,
        ALTERNATE_TERRAIN = 0x20,
        DELETED = 0x40,
        NO_DELETED = 0xbf,
        PLAZA_OR_EARTHQUAKE = 0x80,
        NO_PLAZA = 0x7f,
        NO_CONSTRUCTION_AND_DELETED = 0xaf,
    }

    public static class BitTypeExtensions
    {
        public static int GetBuildingSize(this BitType tile)
        {
            switch (tile & BitType.SIZES)
            {
                case BitType.SIZE2: return 2;
                case BitType.SIZE3: return 3;
                case BitType.SIZE4: return 4;
                case BitType.SIZE5: return 5;
                case BitType.SIZE7: return 7;
                default: return 1;
            }
        }

        public static bool IsPlazaOrEarthquake(this BitType tile)
        {
            return (tile & BitType.PLAZA_OR_EARTHQUAKE) > 0;
        }
    }
}
