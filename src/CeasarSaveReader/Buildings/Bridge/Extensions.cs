namespace CeasarSaveReader.Buildings.Bridge
{
    public static class Extensions
    {
        public static BridgrType GetBridgeType(this int sprite)
        {
            if (sprite >= 1 && sprite <= 6)
            {
                return BridgrType.Low;
            }
            if (sprite >= 7 && sprite <= 15)
            {
                return BridgrType.Ship;
            }
            throw new InvalidOperationException("Unexpected bridge sprite value. This method only works for bridges");
        }

        public static BridgeSectionType GetBridgeSectionType(this int sprite)
        {
            if (sprite >= 1 && sprite <= 4)
            {
                return BridgeSectionType.Ramp;
            }
            if (sprite >= 5 && sprite <= 6)
            {
                return BridgeSectionType.Span;
            }
            if (sprite >= 7 && sprite <= 10)
            {
                return BridgeSectionType.Ramp;
            }
            if (sprite >= 11 && sprite <= 12)
            {
                return BridgeSectionType.Span;
            }
            if (sprite == 13)
            {
                return BridgeSectionType.RampPillar;
            }
            if (sprite >= 14 && sprite <= 15)
            {
                return BridgeSectionType.Pillar;
            }

            throw new InvalidOperationException("Unexpected bridge sprite value. This method only works for bridges");
        }

        public static int GetBridgeOrientation(this int sprite)
        {
            if (sprite >= 1 && sprite <= 4)
            {
                return (-sprite + 5) % 4;
            }
            if (sprite >= 5 && sprite <= 6)
            {
                return sprite - 5;
            }
            if (sprite >= 7 && sprite <= 10)
            {
                return (-sprite + 11) % 4;
            }
            if (sprite >= 11 && sprite <= 12)
            {
                return sprite - 11;
            }
            if (sprite == 13)
            {
                return 0;
            }
            if (sprite >= 14 && sprite <= 15)
            {
                return sprite - 14;
            }

            throw new InvalidOperationException("Unexpected bridge sprite value. This method only works for bridges");
        }
    }
}
