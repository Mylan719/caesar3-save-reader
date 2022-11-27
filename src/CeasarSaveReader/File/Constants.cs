using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.File
{
    public class Constants
    {
        public const int GRID_SIZE = 162;

        public const uint UNCOMPRESSED = 0x80000000;
        public const int PIECE_SIZE_DYNAMIC = 0;

        public const int SAVE_GAME_CURRENT_VERSION = 0x89;
        public const int SAVE_GAME_LAST_ORIGINAL_LIMITS_VERSION = 0x66;
        public const int SAVE_GAME_LAST_SMALLER_IMAGE_ID_VERSION = 0x76;
        public const int SAVE_GAME_LAST_NO_DELIVERIES_VERSION = 0x77;
        public const int SAVE_GAME_LAST_STATIC_VERSION = 0x78;
        public const int SAVE_GAME_LAST_JOINED_IMPORT_EXPORT_VERSION = 0x79;
        public const int SAVE_GAME_LAST_STATIC_BUILDING_COUNT_VERSION = 0x80;
        public const int SAVE_GAME_LAST_STATIC_MONUMENT_DELIVERIES_VERSION = 0x81;
        public const int SAVE_GAME_LAST_STORED_IMAGE_IDS = 0x83;
        public const int SAVE_GAME_INCREASE_GRANARY_CAPACITY = 0x85;
        public const int SAVE_GAME_LAST_ORIGINAL_TERRAIN_DATA_SIZE_VERSION = 0x86;
        public const int SAVE_GAME_LAST_CARAVANSERAI_WRONG_OFFSET = 0x87;
        public const int SAVE_GAME_LAST_ZIP_COMPRESSION = 0x88;
    }
}
