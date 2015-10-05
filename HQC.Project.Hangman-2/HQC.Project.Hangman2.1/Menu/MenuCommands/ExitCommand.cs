// <copyright file="ExitCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.Commands.MenuCommands;
    using HQC.Project.Hangman.UI;

    /// <summary>
    /// Exit the game
    /// </summary>
    public class ExitCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        /// <param name="logger">???</param>
        public ExitCommand(ILogger logger)
            : base(logger)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Logger.PrintGoodBuyMessage();
            Environment.Exit(0);
        }
    }
}
