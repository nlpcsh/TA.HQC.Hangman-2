// <copyright file="ShowGameRulesCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using System;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Menu.MenuCommands;
    using HQC.Project.Hangman.UI.Common;

    /// <summary>
    /// Show on user game rules
    /// </summary>
    public class ShowGameRulesCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowGameRulesCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public ShowGameRulesCommand(ILogger logger)
            : base(logger)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Logger.Print(Messages.rulesInfo);
            Console.ReadKey();
        }
    }
}
