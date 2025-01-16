using snake;

namespace Snake;

public class GameState
{
   // Properties for game dimensions and state
   public int Rows { get; }              // Number of grid rows
   public int Columns { get; }           // Number of grid columns
   public GridValue[,] Grid { get; }     // The game grid storing cell states
   public Direction Dir { get; private set; }  // Current snake direction
   public int Score { get; private set; }      // Current score
   public bool IsGameOver { get; private set; } // Game over state

   // Collections for managing snake state
   private readonly LinkedList<Direction> _directionChanges = new(); // Buffer for pending direction changes
   private readonly LinkedList<Position> _snakePosition = new();     // Snake body positions from head to tail
   private readonly Random _random = new Random();                   // For random food placement

   // Constructor: Initializes game grid and starting state
   public GameState(int rows, int columns)
   {
       Rows = rows;
       Columns = columns;
       Grid = new GridValue[Rows, Columns];
       Dir = Direction.right;            // The Snake starts moving right
       AddSnake();                       // Place initial snake
       AddFood();                        // Place first food
   }

   // Places the initial snake in the middle of the grid
   private void AddSnake()
   {
       int startingRow = Rows / 2 - 1;
       for (int c = 1; c <= 3; c++)     // Creates a snake of length 3
       {
           Grid[startingRow, c] = GridValue.Snake;
           _snakePosition.AddFirst(new Position(startingRow, c));
       }
   }

   // Returns all empty grid positions using yield return for efficiency
   private IEnumerable<Position> EmptyPositions()
   {
       for (int r = 0; r < Rows; r++)
       {
           for (int c = 0; c < Columns; c++)
           {
               if (Grid[r, c] == GridValue.Empty)
               {
                   yield return new Position(r, c);
               }
           }
       }
   }

   // Places food at a random empty position
   private void AddFood()
   {
       List<Position> emptyPositions = new List<Position>(EmptyPositions());
       if (emptyPositions.Count == 0)    // If grid is full
       {
           return;
       }

       // Stores a random position from empty positions to be used updating the grid value
       Position food = emptyPositions[_random.Next(emptyPositions.Count)];
       //Updates the grid value to 'Food'
       Grid[food.Row, food.Column] = GridValue.Food;
   }

   // Getter methods to access snake positions
   public Position GetHeadPosition() => _snakePosition.First.Value;
   public Position GetTailPosition() => _snakePosition.Last.Value;
   public IEnumerable<Position> GetSnakePosition() => _snakePosition;

   // Adds a new head position to the snake (for movement and growth)
   private void AddSnakeHead(Position position)
   {
       _snakePosition.AddFirst(position);             // Add to linked list
       Grid[position.Row, position.Column] = GridValue.Snake;  // Update grid
   }

   // Removes the tail (for movement without growth)
   private void RemoveSnakeTail()
   {
       Position snakeTail = _snakePosition.Last.Value;
       Grid[snakeTail.Row, snakeTail.Column] = GridValue.Empty;  // Clear grid position
       _snakePosition.RemoveLast();                              // Remove from linked list
   }

   // Gets the last queued direction change or current direction if none queued
   private Direction GetLastDirection()
   {
       if (_directionChanges.Count == 0) return Dir;
       return _directionChanges.Last.Value;
   }



   // Validates if a direction change is legal
   private bool CanChangeDirection(Direction newDirection)
   {
       // - Cannot have more than 2 pending changes
       if (_directionChanges.Count == 2)
       {
           return false;
       }

       Direction lastDirection = GetLastDirection();
       // - Cannot reverse direction
       return newDirection != lastDirection && newDirection != lastDirection.Opposite();
   }

   // Queues a direction change if its valid
   public void ChangeDirection(Direction direction)
   {
       if (CanChangeDirection(direction))
       {
           _directionChanges.AddLast(direction);
       }
   }

   // Checks if a position is outside the grid boundaries
   private bool OutsideGrid(Position position)
   {
       return position.Row < 0 || position.Row >= Rows ||
              position.Column < 0 || position.Column >= Columns;
   }

   // Checks what the snake will hit at a new position
   private GridValue WillHit(Position newHeadPosition)
   {
       if (OutsideGrid(newHeadPosition))
       {
           return GridValue.Outside;
       }

       // Special case: Allow moving into current tail position to avoid terminating the game session while moving forward
       if (newHeadPosition == GetTailPosition())
       {
           return GridValue.Empty;
       }

       return Grid[newHeadPosition.Row, newHeadPosition.Column];
   }

   // Main movement logic
   public void Move()
   {
       // Apply any queued direction changes
       if (_directionChanges.Count > 0)
       {
           Dir = _directionChanges.First.Value;
           _directionChanges.RemoveFirst();
       }

       Position newHeadPosition = GetHeadPosition().Translate(Dir);
       GridValue hit = WillHit(newHeadPosition);

       // Handle different collision scenarios
       if (hit == GridValue.Outside || hit == GridValue.Snake)
       {
           IsGameOver = true;                // Hit wall or self - game over
       }
       else if (hit == GridValue.Empty)
       {
           RemoveSnakeTail();               // Normal movement - remove tail
           AddSnakeHead(newHeadPosition);   // add head
       }
       else if (hit == GridValue.Food)
       {
           AddSnakeHead(newHeadPosition);   // Eat food - grow snake
           Score++;                         // Increase score
           AddFood();                       // Place new food
       }
   }
}