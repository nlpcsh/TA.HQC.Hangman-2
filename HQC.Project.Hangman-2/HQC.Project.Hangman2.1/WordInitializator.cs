namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordInitializator
    {
        public bool flag = false;
        public int guessedLetters = 0;
        public List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        private int mistakes = 0;
        private WordGuesser wordGuesser = new WordGuesser();

        public void BegginingOfTheGameInitialization(string word)
        {
            allGuessedLetters = new List<char>();
            hiddenWord = new StringBuilder(new string('_', word.Length));
            hiddenWord = hiddenWord.Replace("_", "_ ");
            Printer.PrintWellcomeMessage();
            Printer.PrintOptionsMessage();
            Printer.PrintSecretWord(hiddenWord.ToString());
        }

        //// helper of the next function
        public void RevealGuessedLetters(string word, char charSupposed)
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

        public void InitializationAfterTheGuess(string word, char charSupposed)
        {
            StringBuilder wordInitailized = new StringBuilder();

            if (allGuessedLetters.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revealed the letter {0}", charSupposed);
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
                //CommandManager.Start();
                // Go to GameEngine logic
                var newGame = new GameEngine();
                newGame.NewGame();
                //return;
            }

            Console.WriteLine("The secret word is:");
            Console.WriteLine(hiddenWord);
        }

        public void RevealTheNextLetter(string word)
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < word.Length; i++)
            {
                if (this.allGuessedLetters[i].Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            this.InitializationAfterTheGuess(word, firstUnrevealedLetter);

            //// flag - not in the chart
            this.flag = true;
        }

        public void EndOfTheGameInitialization(string word)
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
