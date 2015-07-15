Refactoring Documentation for Project “Hangman 2”
------------------------------------------------------

1.  Redesigned the project structure: Team “Hangman-2”
	-   Added class Hangman and moved Main() inside
	-   Created class 'Player'(replaced class 'PlayerMistakes').
	-   ...

2.  Reformatted the source code:
	-	Removed all unneeded empty lines, e.g. in the method all methods inside.
	-	placed curly braces **{** and **}** in `for` anf `if` statements 
	-   Inserted empty lines between the methods.
	-   Split the lines containing several statements into several simple lines, e.g.
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.

3.  Renamed variables:
	-   In class WordInitializator: 'num1' to 'guessedLetters';
	-	In class WordInitializator: 'num2' to 'mistakes';
	-	Renamed class 'Hangman' to 'HangmanStartPoint';

4.  Introduced constants:
	-   Като гледам все оше нямаме константи.
