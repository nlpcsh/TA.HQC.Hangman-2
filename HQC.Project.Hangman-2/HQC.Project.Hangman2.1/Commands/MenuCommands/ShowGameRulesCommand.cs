// <copyright file="ShowGameRulesCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2;

    /// <summary>
    /// Show on user game rules
    /// </summary>
    public class ShowGameRulesCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowGameRulesCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public ShowGameRulesCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Game.Logger.PrintMenuHelpOption();
        }
    }
}
