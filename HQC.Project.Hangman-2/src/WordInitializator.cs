namespace HQC.Project.Hangman2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordInitializator
    {
        public static bool flag = false;
        public static int guessedLetters = 0;
        public static List<char> allGuessedLetters;
        private static StringBuilder hiddenWord;
        private static int mistakes = 0;
        private static WordGuesser wordGuesser = new WordGuesser();

        public static void BegginingOfTheGameInitialization(string word)
        {
            allGuessedLetters = new List<char>();
            hiddenWord = new StringBuilder(new string('_', word.Length));
            hiddenWord = hiddenWord.Replace("_", "_ ");
            Printer.PrintStartHangmanGameMessage(hiddenWord.ToString());
        }

        //// helper of the next function
        public static void RevealGuessedLetters(string word, char charSupposed)
        {
            var startIndex = 0;
            var index = word.IndexOf(charSupposed, startIndex);

            while (index != -1)
            {
                hiddenWord[index * 2] = charSupposed;
                startIndex = index + 1;
                index = word.IndexOf(charSupposed, startIndex);
            }

            Console.WriteLine(hiddenWord);
        }

        public static void InitializationAfterTheGuess(string word, char charSupposed)
        {
            StringBuilder wordInitailized = new StringBuilder();

            if (allGuessedLetters.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revelaed the letter {0}", charSupposed);
                return;
            }

            allGuessedLetters.Add(charSupposed);
            int numberOfTheAppearancesOfTheSupposedChar = word.Count(x => x.Equals(charSupposed));
            RevealGuessedLetters(word, charSupposed);

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
            Console.WriteLine(hiddenWord);
        }

        public static void EndOfTheGameInitialization(string word)
        {
            Console.WriteLine("You won with {0} mistakes.", mistakes);
            //RevealGuessedLetters(word);
            Printer.PrintSecretWord(hiddenWord.ToString());
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
