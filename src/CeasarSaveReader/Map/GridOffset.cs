using System.Diagnostics.CodeAnalysis;

namespace CeasarSaveReader.Map
{
    public struct GridOffset
    {
        public static readonly GridOffset Zero = new GridOffset(0, 0);

        public const int GRID_SIZE = 162;
        public int X { get; }
        public int Y { get; }
        public int Value => Y * GRID_SIZE + X;

        public GridOffset(int x, int y)
        {
            X = x;
            Y = y;
        }

        public GridOffset(int offset)
            : this(offset % GRID_SIZE, offset / GRID_SIZE)
        {

        }

        public GridOffset Left() => new(X - 1, Y);
        public GridOffset Right() => new(X + 1, Y);
        public GridOffset Up() => new(X, Y + 1);
        public GridOffset Down() => new(X, Y - 1);

        public GridOffset UpperLeft() => new(X - 1, Y + 1);
        public GridOffset UpperRight() => new(X + 1, Y + 1);
        public GridOffset LowerLeft() => new(X - 1, Y - 1);
        public GridOffset LowerRight() => new(X + 1, Y - 1);

        public GridOffset[] GetPattern() => new[]  {
            UpperLeft(), Up(), UpperRight(),
            Left(), this, Right(),
            LowerLeft(), Down(), LowerRight()
        };

        public int ManhattanDistance() => Math.Abs(X) + Math.Abs(Y);

        public override string ToString() => $"{X}; {Y}";

        public static GridOffset operator -(GridOffset left, GridOffset right)
        {
            return new(left.X - right.X, left.Y - right.Y);
        }

        public static GridOffset operator +(GridOffset left, int right)
        {
            return new(left.X + right, left.Y + right);
        }

        public static bool operator !=(GridOffset left, GridOffset right)
        {
            return left.Value != right.Value;
        }

        public static bool operator ==(GridOffset left, GridOffset right)
        {
            return left.Value == right.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is GridOffset otherOffset)
            {
                return Value == otherOffset.Value;
            }
            return false;
        }
    }
}
