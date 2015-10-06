// <copyright file="Player.cs" company="PlaceholderCompany">
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
        /// <param name="playerName">???</param>
        /// <param name="score">???</param>
        public Player(string playerName, int score)
            : this()
        {
            this.Name = playerName;
            this.Score = score;
        }

        /// <summary>
        /// ???
        /// </summary>
        public string HiddenWord { get; set; }


        /// <summary>
        /// ???
        /// </summary>
        public string Word { get; set; }

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
            if (this.Score <= otherPlayer.Score)
            {
                return -1;
            }
            else
            {
                //// the newer one replaces the older
                return 1;
            }
        }
    }
}
