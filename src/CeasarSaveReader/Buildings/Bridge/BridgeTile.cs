using CeasarSaveReader.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Buildings.Bridge
{
    public record BridgeTile
    {
        public GridOffset Coordinates { get; init; }
        public BridgeSectionType BridgeSection { get; init; }
        public BridgrType Type { get; init; }
        public int Orientation { get; init; }
    }
}
