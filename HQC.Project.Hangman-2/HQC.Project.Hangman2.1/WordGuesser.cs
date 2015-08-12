﻿namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordGuesser
    {
        private List<char> allGuessedLetters;
        private StringBuilder hiddenWord;
        //private bool isNextLetterToReveal = false;
        private int guessedLetters = 0;
        private int mistakes = 0;

        private bool isRevelingMoreLetters = true;

        public WordGuesser()
        {
            this.allGuessedLetters = new List<char>();
            //this.Scores = new ScoreBoard();
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

        //public ScoreBoard Scores { get; set; }

        public void InitializationOfGame()
        {
            this.hiddenWord = new StringBuilder(new string('_', this.Word.Length));
            this.hiddenWord = this.hiddenWord.Replace("_", "_ ");

            Printer.PrintSecretWord(this.hiddenWord.ToString());
        }

        //// 2 methods from WordInitializator must be moved here!
        //public string GuessLetter()
        //{
        //    Console.WriteLine("Enter your guess: ");
        //    string supposedCharOrCommand = Console.ReadLine().ToLower();

        //    //// the input is a character
        //    if (supposedCharOrCommand.Length == 1)
        //    {
        //        char supposedChar = supposedCharOrCommand[0];
        //        InitializationAfterTheGuess(supposedChar);
        //    }
        //    else if (supposedCharOrCommand.Equals(Command.help.ToString()))
        //    {
        //        this.RevealTheNextLetter();
        //    }
        //    //else if (supposedCharOrCommand.Equals("restart"))
        //    //{
        //    //    execute.Start(wordSelect, wordInit);
        //    //}
        //    //else if (supposedCharOrCommand.Equals("exit"))
        //    //{
        //    //    execute.Exit();
        //    //    return;
        //    //}
        //    else if (supposedCharOrCommand.Equals(Command.top.ToString()))
        //    {
        //        this.Scores.PrintTopResults();
        //    }

        //    return supposedCharOrCommand;
        //}

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
            //StringBuilder wordInitailized = new StringBuilder();


            if (this.allGuessedLetters.Contains<char>(supposedChar))
            {
                Console.WriteLine("You have already revealed the letter {0}", supposedChar);

                isRevelingMoreLetters = true;
                return isRevelingMoreLetters;
            }

            this.allGuessedLetters.Add(supposedChar);
            int numberOfTheAppearancesOfTheSupposedChar = this.Word.Count(x => x.Equals(supposedChar));
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
            if (this.guessedLetters == this.Word.Length)
            {
                //EndOfTheGameInitialization(word);
                //this.EndOfTheGame();
                //CommandManager.Start();
                // Go to GameEngine logic
                //GameEngine.gameIsOn = false;

                isRevelingMoreLetters = false;
                return isRevelingMoreLetters;
            }

            Console.WriteLine("The secret word is:");
            Console.WriteLine(this.hiddenWord);

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

            //// isNextLetterToReveal - not in the chart
            //this.isNextLetterToReveal = true;
        }

        //public void EndOfTheGame()
        //{
        //    Console.WriteLine("You won with {0} mistakes.", mistakes);
        //    //RevealGuessedLetters(word);
        //    Printer.PrintSecretWord(this.hiddenWord.ToString());
        //    Console.WriteLine("Please enter your name for the top scoreboard:");
        //    string playerName = Console.ReadLine();
        //    Player currentPlayer = new Player(playerName, mistakes);

        //    //wordGuesser.Scores.PlacePlayerInScoreBoard(currentPlayer);
        //    this.Scores.PlacePlayerInScoreBoard(currentPlayer);
        //    this.guessedLetters = 0;
        //    this.mistakes = 0;
        //    this.isNextLetterToReveal = false;
        //}
    }
}
