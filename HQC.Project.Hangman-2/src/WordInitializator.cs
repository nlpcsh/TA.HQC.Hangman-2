namespace HQC.Project.Hangman2
{
    using System;
    using System.Linq;
    using System.Text;

    public class WordInitializator
    {
        public static bool flag = false;
        public static int guessedLetters = 0;
        public static char[] allGuessedLetters;
        private static int mistakes = 0;
        private static WordGuesser wordGuesser = new WordGuesser();

        public static void BegginingOfTheGameInitialization(string word)
        {
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");
            allGuessedLetters = new char[word.Length];

            StringBuilder hiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                allGuessedLetters[i] = '$';
                hiddenWord.Append("_ ");
            }

            Console.WriteLine();
            Console.WriteLine("The secret word is: ");
            Console.WriteLine(hiddenWord);
            Console.WriteLine();
        }

        // helper of the next function
        public static void RevealGuessedLetters(string word) 
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (allGuessedLetters[i].Equals('$'))
                {
                    partiallyHiddenWord.Append("_ ");
                }
                else
                {
                    partiallyHiddenWord.Append(allGuessedLetters[i].ToString() + " ");
                }
            }

            Console.WriteLine(partiallyHiddenWord);
        }

        public static void InitializationAfterTheGuess(string word, char charSupposed)
        {
            StringBuilder wordInitailized = new StringBuilder();
            int numberOfTheAppearancesOfTheSupposedChar = 0;

            if (allGuessedLetters.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revelaed the letter {0}", charSupposed);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(charSupposed))
                {
                    allGuessedLetters[i] = word[i];
                    numberOfTheAppearancesOfTheSupposedChar++;
                }
            }

            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", charSupposed);
                mistakes++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.", numberOfTheAppearancesOfTheSupposedChar);
                guessedLetters += numberOfTheAppearancesOfTheSupposedChar;
            }

            Console.WriteLine();

            //// check if the word is guessed
            if (guessedLetters == word.Length) 
            {
                EndOfTheGameInitialization(word);
                CommandExecuter.Start();
            }

            Console.WriteLine("The secret word is:");
            RevealGuessedLetters(word);
        }

        //// clear()
        public static void EndOfTheGameInitialization(string word)
        {
            Console.WriteLine("You won with {0} mistakes.", mistakes);
            RevealGuessedLetters(word);
            Console.WriteLine();
            //int positionOfTheFirstFreePositionInTheScoereboard = 4;

            //for (int i = 0; i < 4; i++)
            //{
            //    if (CommandExecuter.scoreboard[i] == null)
            //    {
            //        positionOfTheFirstFreePositionInTheScoereboard = i;
            //        break;
            //    }
            //}

            ////// for free position
            //if ((CommandExecuter.scoreboard[positionOfTheFirstFreePositionInTheScoereboard] == null 
            //      || mistakes <= CommandExecuter.scoreboard[positionOfTheFirstFreePositionInTheScoereboard].Mistakes) //// when the 4th pos is not free)
            //      && flag == false)
            //{
            //    Console.WriteLine("Please enter your name for the top scoreboard:");
            //    string playerName = Console.ReadLine();
            //   Player newResult = new Player(playerName, mistakes);
            //    CommandExecuter.scoreboard[positionOfTheFirstFreePositionInTheScoereboard] = newResult;

            //    for (int i = positionOfTheFirstFreePositionInTheScoereboard; i > 0; i--)
            //    {
            //        if (CommandExecuter.scoreboard[i].Compare(CommandExecuter.scoreboard[i - 1]) < 0)
            //        {
            //            //// swap
            //            Player temp = CommandExecuter.scoreboard[i];
            //            CommandExecuter.scoreboard[i] = CommandExecuter.scoreboard[i - 1];
            //            CommandExecuter.scoreboard[i - 1] = temp;
            //        }
            //    }
            //}

            Console.WriteLine("Please enter your name for the top scoreboard:");
            string playerName = Console.ReadLine();
            Player currentPlayer = new Player(playerName, mistakes);
            wordGuesser.Scores.PlacePlayerInScoreBoard(currentPlayer);

            guessedLetters = 0;
            mistakes = 0;
            flag = false;
        }
    }
}
