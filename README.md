Refactoring Documentation for Project “Hangman 2”
------------------------------------------------------

1.  **Redesigned** the project structure: Team “Hangman-2”
	-   Added class `HangmanStartPoint` and moved `Main()` inside. Its method `Start()` makes the game begin (takes UI and CommandFactory abstraction).
	-   class `CommandFactory` - easy create command by abstract factory pattern
	-   abstract class `MenuComand` inherited by Menu commands: `PlayCommand`, `ShowGameRulesCommand`, `TopCommand` and `ExitCommand` classes
	-   class `HangmanGame` - initializes a new game
	-   class `Player`(replaced class `PlayerMistakes`)
	-   class `Globals` (static) - holder of all constants in the game
	-   (partial) class `Messages` - all game messages 
	-   abstract class `State` inherited by: `InitializeGameState`, `ChooseCategoryState`,  `PlayerInitializationState`, `PlayGameState`, `RestartGameState` and `EndGameState` - all possible states in the game.
	-   Added class `ConsoleUI` - implements interface `IUI`. It holds all UI logic and communicates with its interface
	-   Added class `WordSelectorFromFile` - to read word from file, not from array
	-   Create class `ImportTopPlayers` that implements `IPlayersImporter` interface
	-   Rename and move `ReadFromTxtFile()` method to `ImportPlayers()` method in `ImportTopPlayers` class
	-   In `ScoreBoard` class add method `LoadTopPlayers()` that invokes `ImportTopPlayers`
    -   Load top players in `TopCommand` class
    -   Add file name validation method in `Validator` class and use it in `WordSelectorFromFile` class
    -   Add interface `IExporter` and class `FileExporter`
    -   Move `SaveToTxtFile()` method in `FileExporter` class
    -   Remove `Compare()` method from `Player` class.

2.  **Reformatted** the source code:
	-   General refactoring of class all the classes
	-   Split the lines containing several statements into several simple lines, e.g.
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
	-   Renamed most of the variables with proper names
	-   Introduced game constants (in class `Globals`)

3.  Game **features**:
    -   Make commands case insensitive
    -   Added WPF UI (still not connected to the game)
    -   Improved display top player's scores (show in descending order)
    -   Improved game console UI
    -   Input validation
    -   Give to the user a possibility to choose word from different categories

4.  Implemented **design patterns**:
    -   **Singleton** Pattern for `ScoreBoard` (not thread save) - only one scoreboard in the game is needed
    -   **Lazy Initialization** for `ScoreBoard` - 
    -   **Strategy** Pattern for output messages (OCR, DI)
    -   **Strategy** Pattern for selecting word via `IWordsImporter` interface
    -   **Strategy** Pattern for importing player via `IPlayerImporter` interface
    -   **State** Pattern for game logic via `IState` interface and its child classes
    -   **Abstract Factory** Pattern for creating commands via `ICommandFactory` interface
    -   **Command** Pattern to execute user commands via `ICommand` interface and its child classes

5.  Project documentation in CHM, HTML and MD formats

