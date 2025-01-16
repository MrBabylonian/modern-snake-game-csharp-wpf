🐍 Modern Snake Game

A sleek, modern take on the classic Snake game, built with C# 13 and WPF, featuring smooth animations, clean architecture, and responsive controls.

🎮 Quick Start

Download and Play: No installation needed!
Just double-click and enjoy the classic arcade experience with a modern twist.
✨ Features

Polished Visual Design

Custom pixel-art sprites with retro aesthetics
Smooth animations and death sequences
Dynamic head rotation following movement
Clean, minimalist UI with overlays and scoring
Smart Game Mechanics

Intelligent Direction Buffer: Queues up to 2 moves
Smart Collision System: Detects boundaries and self-collisions
Progressive Challenge: Increases difficulty as the snake grows
Real-time score tracking
Technical Excellence

Immutable design patterns for rock-solid game state
Efficient snake management using LinkedList
Smart rendering with transform operations
Async/await patterns for buttery-smooth animations
🎯 How to Play

Launch the game and press ENTER to start
Navigate using the arrow keys
Collect food to grow and score
Avoid walls and your own tail
Challenge yourself to beat your high score!
🔧 Technical Deep Dive

Architecture Highlights

Immutable State Pattern

Thread-safe operations with immutable Position and Direction classes
Bulletproof state management
Zero state mutation bugs
Smart Data Structures

LinkedList for optimal snake body handling
Dictionary-based state-to-visual mapping
O(1) collision checks using array-based grid
Efficient Rendering

Shared image references between grid and UI
Smooth rotation transforms for head movement
Optimized draw cycles
🧩 Design Patterns

Clean Architecture

Separation of game state and visualization logic
Clear responsibility boundaries
Maintainable and testable code
Event-Driven System

Responsive controls
Async game loop for smooth gameplay
Fluid state management
🛠️ Technology Stack

C# 13
WPF (Windows Presentation Foundation)
.NET 9.0
XAML
💡 Key Learnings

Implementation of modern C# 13 features
Clean code architecture principles
Efficient state management techniques
Responsive UI design patterns
Advanced async programming techniques
🚀 Running from Source

Clone the repository
Open in your preferred IDE (Visual Studio or Rider)
Build and run the project
Start playing!
📋 Requirements

Windows OS
.NET 9.0 Runtime
🤝 Contributing

Your contributions are welcome! Here’s how you can help:

Fork the repository
Submit pull requests
Suggest new features
Report issues






