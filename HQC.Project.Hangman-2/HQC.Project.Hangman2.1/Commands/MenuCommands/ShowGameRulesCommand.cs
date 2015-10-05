// <copyright file="ShowGameRulesCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.Commands.MenuCommands;

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
            this.Logger.PrintMenuHelpOption();
        }
    }
}
