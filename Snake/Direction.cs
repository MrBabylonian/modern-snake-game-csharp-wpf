namespace Snake;

public class Direction
{
   // Static predefined Direction objects representing the four possible movements
   // Each Direction is defined by its row and column offsets
   public readonly static Direction left = new Direction(0, -1);    // Move left: same row, -1 column
   public readonly static Direction right = new Direction(0, 1);    // Move right: same row, +1 column
   public readonly static Direction up = new Direction(-1, 0);      // Move up: -1 row, same column
   public readonly static Direction down = new Direction(1, 0);     // Move down: +1 row, same column


   public int RowOffSet { get; }    // Vertical movement offset (-1 for up, +1 for down, 0 for no vertical movement)
   public int ColOffSet { get; }    // Horizontal movement offset (-1 for left, +1 for right, 0 for no horizontal movement)

   // Private constructor - makes sure the Directions can only be created through the predefined static instances
   private Direction(int rowOffSet, int colOffSet)
   {
       RowOffSet = rowOffSet;
       ColOffSet = colOffSet;
   }

   // Creates a new Direction representing the opposite movement
   // Used to prevent snake from reversing into itself
   public Direction Opposite()
   {
       return new Direction(-RowOffSet, -ColOffSet);  // Negates both offsets to get opposite direction
   }

   // Helper method for equality comparison
   // Compares row and column offsets of two directions
   protected bool Equals(Direction other)
   {
       return RowOffSet == other.RowOffSet && ColOffSet == other.ColOffSet;
   }

   // Standard object equality override
   // Handles null checks and type checking before comparing directions
   public override bool Equals(object? obj)
   {
       if (obj is null) return false;                    // Null check
       if (ReferenceEquals(this, obj)) return true;      // Same instance check
       if (obj.GetType() != typeof(Direction)) return false;  // Type check
       return Equals((Direction)obj);                    // Value comparison
   }

   // Generates hash code for using Direction in hash-based collections
   // Combines row and column offset values for unique hash
   public override int GetHashCode()
   {
       return HashCode.Combine(RowOffSet, ColOffSet);
   }

   // Operator overloads for == and != to allow natural syntax
   // when comparing directions
   public static bool operator ==(Direction? left, Direction? right)
   {
       return Equals(left, right);
   }

   public static bool operator !=(Direction? left, Direction? right)
   {
       return !Equals(left, right);
   }
}