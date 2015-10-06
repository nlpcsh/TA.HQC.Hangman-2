// <copyright file="PlayCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.Commands.MenuCommands;
    using HQC.Project.Hangman2.GameStates;
    using HQC.Project.Hangman2.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class PlayCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public PlayCommand(ILogger logger)
            : base(logger)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            var wordSelector = new WordSelectorFromFile("../../Words/Random.txt");
            var scores = ScoreBoard.Instance;
            var player = new Player();
            var caommandFactory = new CommandFactory();

            var game = new HangmanGame(this.Logger, new PlayerInitializationState(), wordSelector, scores, player, caommandFactory);
            game.StartGame();
        }
    }
}
