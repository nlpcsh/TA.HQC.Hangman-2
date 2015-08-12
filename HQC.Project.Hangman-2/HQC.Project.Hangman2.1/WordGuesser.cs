namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordGuesser
    {
        private List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        private int guessedLetters = 0;
        private int mistakes = 0;

        private bool isRevelingMoreLetters = true;

        public WordGuesser()
        {
            this.allGuessedLetters = new List<char>();
        }

        internal string Word { get; set; }

        internal int Mistakes
        {
            get
            {
                return this.mistakes;
            }

            set
            {
                this.mistakes = value;
            }
        }

        internal string HiddenWord
        {
            get
            {
                return hiddenWord.ToString();
            }
        }

        public void InitializationOfGame()
        {
            this.hiddenWord = new StringBuilder(new string('_', this.Word.Length));
            this.hiddenWord = this.hiddenWord.Replace("_", "_ ");

            for (int i = 0; i < this.Word.Length; i++)
            {
                this.allGuessedLetters.Add('$');
                //hiddenWord.Append("_ ");
            }

            Printer.PrintSecretWord(this.hiddenWord.ToString());
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

            Console.WriteLine(this.hiddenWord);
        }

        public bool InitializationAfterTheGuess(char supposedChar)
        {
            if (this.allGuessedLetters.Contains<char>(supposedChar))
            {
                Console.WriteLine("You have already revealed the letter {0}", supposedChar);

                isRevelingMoreLetters = true;
                return isRevelingMoreLetters;
            }

            int numberOfTheAppearancesOfTheSupposedChar = this.Word.Count(x => x.Equals(supposedChar));

            for (int i = 0; i < this.Word.Length; i++)
            {
                if (this.Word[i].Equals(supposedChar))
                {
                    this.allGuessedLetters[i] = Word[i];
                    //numberOfTheAppearancesOfTheSupposedChar++;
                }
            }

            //this.allGuessedLetters.Add(supposedChar);

            
            this.RevealGuessedLetters(supposedChar);

            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", supposedChar);
                this.Mistakes++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.", numberOfTheAppearancesOfTheSupposedChar);
                this.guessedLetters += numberOfTheAppearancesOfTheSupposedChar;
            }

            Console.WriteLine();

            //// check if the word is guessed
            if (this.guessedLetters >= this.Word.Length)
            {
                isRevelingMoreLetters = false;
                return isRevelingMoreLetters;
            }

            Console.WriteLine("The secret word is:");
            Console.WriteLine(this.HiddenWord);

            isRevelingMoreLetters = true;
            return isRevelingMoreLetters;
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
        }
    }
}
