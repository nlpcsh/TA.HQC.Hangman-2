Refactoring Documentation for Project “Hangman 2”
------------------------------------------------------

1.  **Redesigned** the project structure: Team “Hangman-2”
	-   Added class `Hangman` and moved `Main()` inside
	-   Added class `ScoreBoard` and moved all related functionality in it. It contains methods:
		- `SaveScoresToTxtFile()`
		- `ReadScoresFromTxtFile()`
		- `PrintTopResults()`
		- `GetFirstFreePosition()`
		- `PlacePlayerInScoreBoard()`
	-   Added class `Player`(replaced class `PlayerMistakes`)
	-   Added class `Printer` (static) - containing all general messages in the game
	-   Added class `Globals` (static) - holder of all constants in the game
	-   Removed class `WorldInitializator` - all methods passed to `GameEngine` and `WordGuesser` classes
	-   Added class `GameEngine` containing methods: 
		- `NewGame()`
		- `PlayAgain()`
		- `EndOfTheGame()`
	-   Added class `Validator` (static) containing major validation methods:
	-   Added interface `ILogger` containing method `LogLine()` - to implement Dependency Inversion for the output printing
	-   Added enumeration `Command` containing all valid for the game commands
	-   Changed class `CommandExecuter` to `CommandManager` containing methods:
		- `ReadInput()`
	-   Added class `ConsoleLogger` - implements interface `ILogger`
	-   Implemented in the class `WordGuesser` new methods:
		- `InitializationOfGame()`
		- `RevealGuessedLetters()`
		- `InitializationAfterTheGuess()`
		- `RevealTheNextLetter()`
	-   Added class `WordSelectorFromFile` - to read word from file, not from array
	-   Extracted the method `GenerateRandomGame()` from the method `Main()`
	-   Renamed class `Hangman` to `HangmanStartPoint`
	-   Update methods `RevealGuessedLetters()` and `InitializationAfterTheGuess()`
	-   Create class `ImportTopPlayers` that implements `IPlayersImporter` interface
	-   Rename and move `ReadFromTxtFile()` method to `ImportPlayers()` method in `ImportTopPlayers` class
	-   In `ScoreBoard` class add method `LoadTopPlayers()` that invokes `ImportTopPlayers`
    -   Load top players in `TopCommand` class
    -   Add file name validation method in `Validator` class and use it in `WordSelectorFromFile` class
    -   Add interface `IExporter` and class `FileExporter`
    -   Move `SaveToTxtFile()` method in `FileExporter` class
    -   Remove `Compare()` method from `Player` class.
2.  **Reformatted** the source code:
	-   General refactoring of class `WorldInitializator`
		- Removed all unneeded empty lines, e.g. in the method all methods inside.
	-   Split the lines containing several statements into several simple lines, e.g.:
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
	-   Renamed variables:
		-   In class `WordInitializator`: `allGuessedLettersOrderedByPositionInTheWord` to `allGuessedLetters`
		-   In class `WordInitializator`: `num1` to `guessedLetters`
		-   In class `WordInitializator`: `num2` to `mistakes`
		-   In class `WordInitializator`: `flag` to `isNextLetterToReveal`
		-   In class `WordInitializator`: `partiallyHiddenWord` to `hiddenWord`.
	-  Introduced constants (in class `Globals`):
		-   `ScoreBoardSize = 5`
		-   `LastPositionInScoreBoard = 4`
		-   `FreePositionInScoreBoars = "unknown-0"`
		-   `NoPlayer = "No Player"`.
3.  Game **features**:
    -   Make commands insensitive
    -   Add command "wrong" in commands
    -   Add WPF app(only UI for now)
    -   Improved display top player's scores (show in descending order)
    -   Improved game UI
    -   Input validation

4.  Implemented **design patterns**:
    -   **Singleton** Pattern for `ScoreBoard` (thread save)
    -   **Strategy** Pattern for output messages (OCR, DI)
    -   **Strategy** Pattern for selecting word via `IWordsImporter` interface
    -   **Strategy** Pattern for importing player via `IPlayerImporter` interface

