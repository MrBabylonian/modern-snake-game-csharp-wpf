using Snake;

namespace snake;

public class Position
{
    // Read-only properties for grid coordinates
    public int Row { get; } // Row position in grid
    public int Column { get; } // Column position in grid

    // Constructor initializes immutable position
    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    // Creates a new Position offset by a Direction
    // Used for calculating snake's next position during movement
    public Position Translate(Direction direction)
    {
        return new Position(
            Row + direction.RowOffSet, // Calculate new row
            Column + direction.ColOffSet // Calculate new column
        );
    }

    // Helper method for equality comparison
    // Compares row and column values of two positions
    protected bool Equals(Position other)
    {
        return Row == other.Row && Column == other.Column;
    }

    // Standard object equality override
    // Handles null checks and type checking before comparing positions
    public override bool Equals(object? obj)
    {
        if (obj is null) return false; // Null check
        if (ReferenceEquals(this, obj)) return true; // Same instance check
        if (obj.GetType() != typeof(Position)) return false; // Type check
        return Equals((Position)obj); // Value comparison
    }

    // Generates hash code for using Position in hash-based collections
    // Combines row and column values for unique hash
    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    // Operator overloads for == and != to allow natural syntax
    // when comparing positions
    public static bool operator ==(Position? left, Position? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Position? left, Position? right)
    {
        return !Equals(left, right);
    }
}