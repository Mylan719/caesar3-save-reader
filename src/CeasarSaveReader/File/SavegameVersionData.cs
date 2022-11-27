using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.File
{
    public class SavegameVersionData
    {
        public BuildingCounts building_counts { get; set; } = new();
        public PieceSizes piece_sizes { get; set; } = new();
        public bool has_image_grid { get; set; }
        public bool has_monument_deliveries { get; set; }
    };
}
