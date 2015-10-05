// <copyright file="GameEngine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;
    using HQC.Project.Hangman2.Players.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class HangmanGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanGame"/> class.
        /// </summary>
        /// <param name="logger">???</param>
        public HangmanGame(ILogger logger)
        {
            this.WordSelect = new WordSelectorFromFile("../../Words/Random.txt");
            this.Scores = ScoreBoard.Instance;
            this.State = new MenuState();
            this.WordGuess = new Player();
            this.Logger = logger;
            this.CommandFactory = new CommandFactory();
        }

        /// <summary>
        /// ???
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public WordSelectorFromFile WordSelect { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public IPlayer WordGuess { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public ScoreBoard Scores { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// ???
        /// </summary>
        public CommandFactory CommandFactory { get; private set; }

        /// <summary>
        /// ???
        /// </summary>
        internal void StartGame()
        {
            this.State.Play(this);
        }
    }
}
