Refactoring Documentation for Project “Hangman 2”
------------------------------------------------------

1.  Redesigned the project structure: Team “Hangman-2”
	-   Added class Hangman and moved Main() inside
	-   ...
	-   ...
2.  Reformatted the source code:
	-   General refractoring of class `WorldInitializator`
		- Removed all unneeded empty lines, e.g. in the method all methods inside.
		- placed curly braces **{** and **}** in `for` anf `if` statements 
	-   ....
	-   ....
	-   Inserted empty lines between the methods.
	-   Split the lines containing several statements into several simple lines, e.g.:
	
	Before:
	
		if (input\[i\] != ' ') break;
		
	After:

		if (input\[i\] != ' ')
		{
			break;
		}
	
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
	-   …
3.  Renamed variables:
	-   ....
	-   In class `Fifteen`: `number` to `numberOfMoves`.
	-   In `Main(string\[\] args)`: `g` to `gameFifteen`.
4.  Introduced constants:
	-   ....
	-   `GAME\_BOARD\_SIZE = 4`
	-   `SCORE\_BOARD\_SIZE = 5`. 
5.  Extracted the method `GenerateRandomGame()` from the method `Main()`.
6.  Introduced class `ScoreBoard` and moved all related functionality in it.
7.  Moved method `GenerateRandomNumber(int start, int end)` to separate class `RandomUtils`.
8.  …