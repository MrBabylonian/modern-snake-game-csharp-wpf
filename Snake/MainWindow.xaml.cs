using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using snake;


namespace Snake;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Dictionary that maps grid values (Empty, Snake, Food) to their corresponding images
    // Used to easily convert game state to visual representation
    private readonly Dictionary<GridValue, ImageSource> _gridValueToImageSource = new()
    {
        { GridValue.Empty, Images.Empty },
        { GridValue.Snake, Images.Body },
        { GridValue.Food, Images.Food },
    };

    // Dictionary that maps snake's direction to rotation degrees for the head image
    // Used to make snake's head face the direction it's moving
    private readonly Dictionary<Direction, int> _directionToRotation = new()
    {
        { Direction.up, 0 },
        { Direction.right, 90 },
        { Direction.down, 180 },
        { Direction.left, 270 },
    };

    // Game grid dimensions
    private readonly int rows = 20, cols = 20;

    // Array that holds references to all Image controls in the grid
    // Same Image controls are also in GameGrid.Children
    private readonly Image[,] _gridImages;

    // Holds the current game state (snake position, food, score, etc.)
    private GameState _gameState;

    // Flag to prevent multiple game instances from running simultaneously
    private bool _isGameRunning = false;

    // Constructor: Sets up the game grid and initializes game state
    public MainWindow()
    {
        InitializeComponent();
        _gridImages = SetupGrid();     // Create and set up the visual grid
        _gameState = new GameState(rows, cols);  // Initialize game logic
    }

    // Main game execution flow
    private async Task RunGame()
    {
        Draw();                        // Initial draw of the game state
        await ShowCountDown();         // Show 3,2,1 countdown
        Overlay.Visibility = Visibility.Hidden;  // Hide overlay to show game
        await GameLoop();              // Start the main game loop

        // If the game is over, show the game over screen and reset game state
        if (_gameState.IsGameOver)
        {
            await ShowGameOver();
            _gameState = new GameState(rows, cols);
        }
    }

    // Event handler for key presses before they're processed by the window
    private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        // If overlay is visible, consume the key press
        if (Overlay.Visibility == Visibility.Visible)
        {
            e.Handled = true;
        }

        // Start the game only if it's not running and ENTER is pressed
        if(!_isGameRunning && e.Key == Key.Enter)
        {
            _isGameRunning = true;
            await RunGame();
            _isGameRunning = false;
        }
    }

    // Handles directional key inputs during gameplay
    private void Window_Keydown(object sender, KeyEventArgs e)
    {
        if (_gameState.IsGameOver) return;  // Ignore inputs if the game is over

        // Change snake's direction based on arrow key pressed
        switch (e.Key)
        {
            case Key.Left:
                _gameState.ChangeDirection(Direction.left);
                break;
            case Key.Right:
                _gameState.ChangeDirection(Direction.right);
                break;
            case Key.Up:
                _gameState.ChangeDirection(Direction.up);
                break;
            case Key.Down:
                _gameState.ChangeDirection(Direction.down);
                break;
        }
    }

    // Main game loop - moves snake and updates display
    private async Task GameLoop()
    {
        while (!_gameState.IsGameOver)
        {
            await Task.Delay(100);     // Control game speed
            _gameState.Move();         // Update game state
            Draw();                    // Update display
        }
    }

    // Creates and initializes the grid of Image controls
    private Image[,] SetupGrid()
    {
        Image[,] images = new Image[rows, cols];
        GameGrid.Rows = rows;
        GameGrid.Columns = cols;

        // Create Image controls for each cell
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Image emptyImage = new Image
                {
                    Source = Images.Empty,
                    RenderTransformOrigin = new Point(0.5, 0.5)  // For rotation center
                };
                images[r, c] = emptyImage;           // Store image controls in the array
                GameGrid.Children.Add(emptyImage);   // Add to UI
            }
        }

        return images;
    }

    // Coordinates all drawing operations
    private void Draw()
    {
        DrawGrid();                // Update all grid cells
        DrawSnakeHead();          // Special handling for snake's head
        ScoreText.Text = $"Score: {_gameState.Score}";  // Update score
    }

    // Updates the visual state of all grid cells
    private void DrawGrid()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                GridValue gridVal = _gameState.Grid[r, c];  // Get cell state
                // Update the image and reset any rotation
                _gridImages[r, c].Source = _gridValueToImageSource[gridVal];
                _gridImages[r, c].RenderTransform = Transform.Identity;
            }
        }
    }

    // Special handling for snake's head (includes rotation)
    private void DrawSnakeHead()
    {
        Position headPosition = _gameState.GetHeadPosition();
        Image image = _gridImages[headPosition.Row, headPosition.Column];
        image.Source = Images.Head;

        // Rotate head image based on the direction it looks at
        int rotation = _directionToRotation[_gameState.Dir];
        image.RenderTransform = new RotateTransform(rotation);
    }

    // Animates snake's death by changing images with delay
    private async Task DrawDeadSnake()
    {
        List<Position> positions = new(_gameState.GetSnakePosition());

        for (int i = 0; i < positions.Count; i++)
        {
            Position position = positions[i];
            // Head gets dead head image, body gets dead body image
            ImageSource source = i == 0 ? Images.DeadHead : Images.DeadBody;
            _gridImages[position.Row, position.Column].Source = source;
            await Task.Delay(50);  // Delay for animation effect
        }
    }

    // Shows countdown before the game starts
    private async Task ShowCountDown()
    {
        for (int i = 3; i >= 0; i--)
        {
            OverlayText.Text = i.ToString();
            await Task.Delay(1000);  // 1 second between numbers
        }
    }

    // Shows the game over sequence
    private async Task ShowGameOver()
    {
        await DrawDeadSnake();         // Show death animation
        await Task.Delay(1000);        // Wait a second
        Overlay.Visibility = Visibility.Visible;  // Show overlay
        OverlayText.Text = "Press ENTER to start";  // Show the restart message
    }
}