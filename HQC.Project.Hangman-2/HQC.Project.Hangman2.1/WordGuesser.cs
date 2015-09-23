namespace HQC.Project.Hangman
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HQC.Project.Hangman.Interfaces;

    public class WordGuesser : Player
    {
        private ILogger logger;
        private List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        private int guessedLetters = 0;

        private bool isRevelingMoreLetters = true;

        public WordGuesser(ILogger logger)
        {
            this.allGuessedLetters = new List<char>();
            this.logger = logger;
            //this.PrintInitialMessages();
        }

        public WordGuesser(string name, int mistakes)
            : base(name, mistakes)
        {
            this.logger = new ConsoleLogger();
        }

        public WordGuesser()
            : this(new ConsoleLogger())
        {
        }

        internal string Word { get; set; }

        public IList<char> AllGuessedLetters
        {
            get
            {
                return new List<char>(this.allGuessedLetters);
            }
        }

        internal string HiddenWord
        {
            get
            {
                return this.hiddenWord.ToString();
            }
        }

        //private void PrintInitialMessages()
        //{
        //    this.LogLine(Globals.Wellcome);
        //    this.LogLine(Globals.Options);
        //}

        public void InitializationOfGame()
        {
            this.hiddenWord = new StringBuilder(new string('_', this.Word.Length));
            this.hiddenWord = this.hiddenWord.Replace("_", "_ ");

            for (int i = 0; i < this.Word.Length; i++)
            {
                this.allGuessedLetters.Add('$');
                // hiddenWord.Append("_ ");
            }

            Printer.PrintSecretWord(this.hiddenWord.ToString());
            //this.LogLine(this.hiddenWord.ToString());
        }

        public void RevealGuessedLetters(char supposedChar)
        {
            var startIndex = 0;
            var index = this.Word.IndexOf(supposedChar, startIndex);

            while (index != -1)
            {
                this.hiddenWord[index * 2] = supposedChar;
                startIndex = index + 1;
                index = this.Word.IndexOf(supposedChar, startIndex);
            }

            Printer.PrintSecretWord(this.hiddenWord.ToString());
            //this.LogLine(this.hiddenWord.ToString());
        }

        public bool InitializationAfterTheGuess(char supposedChar)
        {
            if (this.allGuessedLetters.Contains<char>(supposedChar))
            {
                //this.LogLine(string.Format("You have already revealed the letter {0}", supposedChar));
                Printer.PrintMessage(string.Format("You have already revealed the letter {0}", supposedChar));
                this.isRevelingMoreLetters = true;
                return this.isRevelingMoreLetters;
            }

            int numberOfTheAppearancesOfTheSupposedChar = this.Word.Count(x => x.Equals(supposedChar));

            for (int i = 0; i < this.Word.Length; i++)
            {
                if (this.Word[i].Equals(supposedChar))
                {
                    this.allGuessedLetters[i] = this.Word[i];
                }
            }

            this.RevealGuessedLetters(supposedChar);

            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                //this.LogLine(string.Format("Sorry! There are no unrevealed letters {0}", supposedChar));
                Printer.PrintMessage(string.Format("There are no unrevealed letters {0}", supposedChar));
                this.Mistakes++;
                this.Lives--;
                Printer.PrintHangman(this.Lives);
            }
            else
            {
                // this.LogLine(string.Format("Good job! You revealed {0} letters.", numberOfTheAppearancesOfTheSupposedChar));
                Printer.PrintMessage(string.Format("Good job! You revealed {0} letters.", numberOfTheAppearancesOfTheSupposedChar));
                this.guessedLetters += numberOfTheAppearancesOfTheSupposedChar;
            }

            this.LogLine(string.Empty);

            // check if the word is guessed
            if (this.guessedLetters >= this.Word.Length)
            {
                this.isRevelingMoreLetters = false;
                return this.isRevelingMoreLetters;
            }

            //this.LogLine("The secret word is:");
            //this.LogLine(this.HiddenWord);

            this.isRevelingMoreLetters = true;
            return this.isRevelingMoreLetters;
        }

        public void RevealTheNextLetter()
        {
           // char firstUnrevealedLetter = '$';
           //
           // for (int i = 0; i < this.Word.Length; i++)
           // {
           //     if (this.allGuessedLetters[i].Equals('$'))
           //     {
           //         firstUnrevealedLetter = this.Word[i];
           //         break;
           //     }
           // }
           //
            //this.LogLine(string.Format("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter));
            //this.InitializationAfterTheGuess(firstUnrevealedLetter);
        }

        public void LogLine(string printMessage)
        {
            // this.logger.LogLine(printMessage);
        }
    }
}
