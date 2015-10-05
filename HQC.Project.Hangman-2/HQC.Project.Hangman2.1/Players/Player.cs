﻿// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HQC.Project.Hangman2.Players.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class Player : IPlayer
    {
        private const int InitialLives = 7;
        private const int InitialMistakes = 0;

        private StringBuilder hiddenWord;
        private int guessedLetters = 0;
        private string word;

        private string name;
        private int mistakes;

        private bool isRevelingMoreLetters = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            this.Lives = Player.InitialLives;
            this.Mistakes = Player.InitialMistakes;
            this.WrongLetters = new HashSet<char>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="playerName">???</param>
        /// <param name="mistakes">???</param>
        public Player(string playerName, int mistakes)
            : this()
        {
            this.Name = playerName;
            this.Mistakes = mistakes;
        }

        /// <summary>
        /// ???
        /// </summary>
        public string HiddenWord
        {
            get
            {
                return this.hiddenWord.ToString();
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public string Word
        {
            get
            {
                return this.word;
            }

            set
            {
                this.word = value;
                this.hiddenWord = new StringBuilder(new string('_', this.word.Length));
            }
        }

        /// <summary>
        /// ???
        /// </summary>
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

        /// <summary>
        /// ???
        /// </summary>
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

        /// <summary>
        /// ???
        /// </summary>
        public int Lives { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public ISet<char> WrongLetters { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="otherPlayer">???</param>
        /// <returns>???</returns>
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

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="supposedChar">???</param>
        public void RevealGuessedLetters(char supposedChar)
        {
            var startIndex = 0;
            var index = this.Word.IndexOf(supposedChar, startIndex);

            while (index != -1)
            {
                this.hiddenWord[index] = supposedChar;
                startIndex = index + 1;
                index = this.Word.IndexOf(supposedChar, startIndex);
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="supposedChar">???</param>
        /// <returns>???</returns>
        public bool InitializationAfterTheGuess(char supposedChar)
        {
            if (this.HiddenWord.Contains<char>(supposedChar))
            {
                this.isRevelingMoreLetters = true;
                return this.isRevelingMoreLetters;
            }

            int numberOfTheAppearancesOfTheSupposedChar = this.Word.Count(x => x.Equals(supposedChar));

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
