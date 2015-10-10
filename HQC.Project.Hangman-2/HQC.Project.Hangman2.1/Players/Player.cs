// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Players
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman.Players.Common;

    /// <summary>
    /// Represents player in the game
    /// </summary>
    public class Player : IPlayer
    {
        private const int InitialLives = 7;
        private const int InitialScore = 0;

        private string name;
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            this.Lives = Player.InitialLives;
            this.Score = Player.InitialScore;
            this.WrongLetters = new HashSet<char>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="playerName">Player's name in game.</param>
        /// <param name="score">Player's score in game.</param>
        public Player(string playerName, int score)
            : this()
        {
            this.Name = playerName;
            this.Score = score;
        }

        /// <summary>
        /// Hidden word that player should guess.
        /// </summary>
        public string HiddenWord { get; set; }

        /// <summary>
        /// Word that player should guess.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Player's name. Makes check for name length.
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
        /// Player's score. Makes check if score is negative value.
        /// </summary>
        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player mistakes cannot be less than 0!");
                }

                this.score = value;
            }
        }

        /// <summary>
        /// Player's lives.
        /// </summary>
        public int Lives { get; set; }

        /// <summary>
        /// Collection of wrong letters that player insert.
        /// </summary>
        public ISet<char> WrongLetters { get; set; }
    }
}
