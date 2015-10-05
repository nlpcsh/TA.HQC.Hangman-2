// <copyright file="ExitCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2;
    using HQC.Project.Hangman2.Commands.Common;

    /// <summary>
    /// Exit the game
    /// </summary>
    public class ExitCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public ExitCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Game.Logger.PrintGoodBuyMessage();
            Environment.Exit(0);
        }
    }
}
