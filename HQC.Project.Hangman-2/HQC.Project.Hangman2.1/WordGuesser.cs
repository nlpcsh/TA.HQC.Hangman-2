namespace HQC.Project.Hangman
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HQC.Project.Hangman.Interfaces;

    public class WordGuesser : Player
    {
        private List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        private int guessedLetters = 0;

        private bool isRevelingMoreLetters = true;

        public WordGuesser()
        {
            this.allGuessedLetters = new List<char>();
            //this.PrintInitialMessages();
        }

        public WordGuesser(string name, int mistakes)
            : base(name, mistakes)
        {
        }


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

        internal string Word { get; set; }


        public void InitializationOfGame()
        {
            this.hiddenWord = new StringBuilder(new string('_', this.Word.Length));
            this.hiddenWord = this.hiddenWord.Replace("_", "_ ");

            for (int i = 0; i < this.Word.Length; i++)
            {
                this.allGuessedLetters.Add('$');
            }
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
        }

        public bool InitializationAfterTheGuess(char supposedChar)
        {
            if (this.allGuessedLetters.Contains<char>(supposedChar))
            {
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
                this.Mistakes++;
                this.Lives--;
                this.WrongLetters.Add(supposedChar);
            }
            else
            {
                this.guessedLetters += numberOfTheAppearancesOfTheSupposedChar;
            }

            //this.LogLine(string.Empty);

            // check if the word is guessed
            if (this.guessedLetters >= this.Word.Length)
            {
                this.isRevelingMoreLetters = false;
                return this.isRevelingMoreLetters;
            }

            this.isRevelingMoreLetters = true;
            return this.isRevelingMoreLetters;
        }

        //public void LogLine(string printMessage)
        //{
        //    // this.logger.LogLine(printMessage);
        //}
    }
}
