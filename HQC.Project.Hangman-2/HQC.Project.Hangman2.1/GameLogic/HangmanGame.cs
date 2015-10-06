﻿// <copyright file="GameEngine.cs" company="PlaceholderCompany">
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
        /// <param name="logger">Used to draw on console</param>
        /// <param name="state">Holds different states while game is running</param>
        /// <param name="wordselector">Select words from .txt file</param>
        /// <param name="scoreboard">Holds best scores from games</param>
        /// <param name="player">Holds information for user</param>
        /// <param name="commandCreator">Returns command from user</param>
        public HangmanGame(ILogger logger, State state, WordSelectorFromFile wordselector, ScoreBoard scoreboard, IPlayer player, CommandFactory commandCreator)
        {
            this.WordSelect = wordselector;
            this.Scores = scoreboard;
            this.State = state;
            this.WordGuess = player;
            this.Logger = logger;
            this.CommandFactory = commandCreator;
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

        public string CurrentCommand { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        internal void StartGame()
        {
            this.State.Play(this);
        }
    }
}
