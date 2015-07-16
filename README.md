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
8.  Renamed class 'Hangman' to 'HangmanStartPoint'.
9.  Created class 'Player'(replaced class 'PlayerMistakes').
10. Put curly braces after all conditionals and loops.
11. Renamed variables 'num1' and 'num2' to 'guessedLetters' and 'mistakes'(class WordInitializator).

12. PS!!! Добавил съм ScoreBoard, но съм го направил статичен, защото в момента нямам много време, като намеря ще го пренапиша или ако някой иска да го разцъка, но според мен първо по - добре да покрием повече от задачите.

13. Changed class ScoreBoard non-static
14. Added methods SaveScoresToTxtFile and ReadScoresFromTxtFile
15. Added  two Global constants: FreePositionInScoreBoars and NoPlayer


!!!!!!! Преди да пушвате бъдете сигурни, че сте сто процента синкнали най - новото защото, някой ми бе затрил препавените методи и трябваше на ново да ги пушвам.

---> Женя: аз съм ти го затрила, но незнам как защото обединих 2та варианта. Явно нещо съм прещакала накрая. Моля те пускай си skype и изрий това като го прочетеш(доста тъпо пишем тук, но няма как да стане без комуникация)  
16.  Update methods RevealGuessedLetters and InitializationAfterTheGuess
