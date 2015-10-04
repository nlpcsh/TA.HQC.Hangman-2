Refactoring Documentation for Project “Hangman 2”
------------------------------------------------------

1.  Redesigned the project structure: Team “Hangman-2”
	-   Added class `Hangman` and moved `Main()` inside
	-   Added class `ScoreBoard` and moved all related functionality in it. It contains methods:
		- `SaveScoresToTxtFile()`
		- `ReadScoresFromTxtFile()`
		- `PrintTopResults()`
		- `GetFirstFreePosition()`
		- `PlacePlayerInScoreBoard()`
	-   Added class `Player`(replaced class `PlayerMistakes`)
	-   Added class `Printer` (static) - contaning all general messages in the game
	-   Added class `Globals` (static) - holder of all constants in the game
	-   Removed class `WorldInitializator` - all methods passed to `GameEngine` and `WordGuesser` classes
	-   Added class `GameEngine` containing methods (v2.1): 
		- `NewGame()`
		- `PlayAgain()`
		- `EndOfTheGame()`
	-   Added class `Validator` (static) containing major validation methods:
	-   Added interface `ILogger` containing method `LogLine()` - to implement Dependency Inversion for the output printing
	-   Added enumeration `Command` containing all valid for the game commands
	-   Changed class `CommandExecuter` to `CommandManager` containing methods:
		- `ReadInput()`
	-   Added class `ConsoleLogger` - implemets interface `ILogger`
	-   Implemented in the class `WordGuesser` new methods:
		- `InitializationOfGame()`
		- `RevealGuessedLetters()`
		- `InitializationAfterTheGuess()`
		- `RevealTheNextLetter()`
	-   Added class `WordSelectorFromFile` - to read word from file, not from array

2.  Reformatted the source code:
	-   General refractoring of class `WorldInitializator`
		- Removed all unneeded empty lines, e.g. in the method all methods inside.
	-   Split the lines containing several statements into several simple lines, e.g.:
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
	-   ...
3.  Renamed variables:
	-   In class `WordInitializator`: `allGuessedLettersOrderedByPositionInTheWord` to `allGuessedLetters`
	-   In class `WordInitializator`: `num1` to `guessedLetters`
	-   In class `WordInitializator`: `num2` to `mistakes`
	-   In class `WordInitializator`: `flag` to `isNextLetterToReveal`
	-   In class `WordInitializator`: `partiallyHiddenWord` to `hiddenWord`.
4.  Introduced constants (in class `Globals`):
	-   `ScoreBoardSize = 5`
	-   `LastPositionInScoreBoard = 4`
	-   `FreePositionInScoreBoars = "unknown-0"`
	-   `NoPlayer = "No Player"`. 
5.  Extracted the method `GenerateRandomGame()` from the method `Main()`.
6.  Renamed class `Hangman` to `HangmanStartPoint`.
7.  Update methods `RevealGuessedLetters()` and `InitializationAfterTheGuess()`
8.  Make commands insensitive
9.  Add command "wrong" in commands
10. Add WPF app(only UI for now)
11. Implement Singleton Pattern for ScoreBoard
