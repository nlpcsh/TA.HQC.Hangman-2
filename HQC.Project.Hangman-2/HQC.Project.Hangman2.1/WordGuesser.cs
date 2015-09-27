namespace HQC.Project.Hangman
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HQC.Project.Hangman.Interfaces;
    using HQC.Project.Hangman2._1.Interfaces;
    using System;

    public class WordGuesser : IPlayer
    {
        private List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        private int guessedLetters = 0;

        private const int InitialLives = 7;
        private const int InitialMistakes = 0;

        private string name;
        private int mistakes;

        private bool isRevelingMoreLetters = true;

        // public WordGuesser()
        // {
        //     this.allGuessedLetters = new List<char>();
        // }

        // public WordGuesser(string name, int mistakes)
        //     : this(name, mistakes)
        // {
        // }


        public WordGuesser()
        {
            this.Lives = WordGuesser.InitialLives;
            this.Mistakes = WordGuesser.InitialMistakes;
            this.WrongLetters = new HashSet<char>();
            this.allGuessedLetters = new List<char>();
        }

        public WordGuesser(string playerName, int mistakes)
            : this()
        {
            this.Name = playerName;
            this.Mistakes = mistakes;
        }

        public List<char> AllGuessedLetters
        {
            get
            {
                return new List<char>(this.allGuessedLetters);
            }

            set
            {
                this.allGuessedLetters = value;
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

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Player must have at least one symbol!");
                }

                this.name = value;
            }
        }

        public int Mistakes
        {
            get
            {
                return this.mistakes;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player mistakes cannot be less than 0!");
                }

                this.mistakes = value;
            }
        }

        public int Lives { get; set; }

        public ISet<char> WrongLetters { get; set; }

        public int Compare(IPlayer otherPlayer)
        {
            if (this.Mistakes <= otherPlayer.Mistakes)
            {
                return -1;
            }
            else
            {
                //// the newer one replaces the older
                return 1;
            }
        }


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
    }
}
