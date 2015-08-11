namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordGuesser
    {
        public List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        public bool isNextLetterToReveal = false;
        public int guessedLetters = 0;
        private int mistakes = 0;

        //public static bool IsExited;

        public WordGuesser()
        {
            this.allGuessedLetters = new List<char>();
            this.Scores = new ScoreBoard();
        }

        public string Word { get; set; }

        public ScoreBoard Scores { get; set; }

        public void InitializationOfGame()
        {
            hiddenWord = new StringBuilder(new string('_', this.Word.Length));
            hiddenWord = hiddenWord.Replace("_", "_ ");

            Printer.PrintSecretWord(hiddenWord.ToString());
        }

        //// 2 methods from WordInitializator must be moved here!
        public string GuessLetter()
        {
            Console.WriteLine("Enter your guess: ");
            string supposedCharOrCommand = Console.ReadLine().ToLower();

            //// the input is a character
            if (supposedCharOrCommand.Length == 1)
            {
                char supposedChar = supposedCharOrCommand[0];
                InitializationAfterTheGuess(supposedChar);
            }
            else if (supposedCharOrCommand.Equals(Command.help.ToString()))
            {
                this.RevealTheNextLetter();
            }
            //else if (supposedCharOrCommand.Equals("restart"))
            //{
            //    execute.Start(wordSelect, wordInit);
            //}
            //else if (supposedCharOrCommand.Equals("exit"))
            //{
            //    execute.Exit();
            //    return;
            //}
            else if (supposedCharOrCommand.Equals(Command.top.ToString()))
            {
                this.Scores.PrintTopResults();
            }

            return supposedCharOrCommand;
        }

        public void RevealGuessedLetters(char supposedChar)
        {
            var startIndex = 0;
            var index = this.Word.IndexOf(supposedChar, startIndex);

            while (index != -1)
            {
                hiddenWord[index * 2] = supposedChar;
                startIndex = index + 1;
                index = this.Word.IndexOf(supposedChar, startIndex);
            }

            Console.WriteLine(hiddenWord);
        }

        public void InitializationAfterTheGuess(char supposedChar)
        {
            StringBuilder wordInitailized = new StringBuilder();

            if (this.allGuessedLetters.Contains<char>(supposedChar))
            {
                Console.WriteLine("You have already revealed the letter {0}", supposedChar);
                return;
            }

            this.allGuessedLetters.Add(supposedChar);
            int numberOfTheAppearancesOfTheSupposedChar = this.Word.Count(x => x.Equals(supposedChar));
            this.RevealGuessedLetters(supposedChar);

            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", supposedChar);
                this.mistakes++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.", numberOfTheAppearancesOfTheSupposedChar);
                guessedLetters += numberOfTheAppearancesOfTheSupposedChar;
            }

            Console.WriteLine();

            //// check if the word is guessed
            if (guessedLetters == this.Word.Length)
            {
                //EndOfTheGameInitialization(word);
                this.EndOfTheGame();
                //CommandManager.Start();
                // Go to GameEngine logic
                GameEngine.gameIsOn = false;

                return;
            }

            Console.WriteLine("The secret word is:");
            Console.WriteLine(hiddenWord);
        }

        public void RevealTheNextLetter()
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < this.Word.Length; i++)
            {
                if (this.allGuessedLetters[i].Equals('$'))
                {
                    firstUnrevealedLetter = this.Word[i];
                    break;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            this.InitializationAfterTheGuess(firstUnrevealedLetter);

            //// isNextLetterToReveal - not in the chart
            this.isNextLetterToReveal = true;
        }

        public void EndOfTheGame()
        {
            Console.WriteLine("You won with {0} mistakes.", mistakes);
            //RevealGuessedLetters(word);
            Printer.PrintSecretWord(hiddenWord.ToString());
            Console.WriteLine("Please enter your name for the top scoreboard:");
            string playerName = Console.ReadLine();
            Player currentPlayer = new Player(playerName, mistakes);

            //wordGuesser.Scores.PlacePlayerInScoreBoard(currentPlayer);
            this.Scores.PlacePlayerInScoreBoard(currentPlayer);
            this.guessedLetters = 0;
            this.mistakes = 0;
            this.isNextLetterToReveal = false;
        }
    }
}
