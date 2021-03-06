﻿// <copyright file="ShowGameRulesCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Commands
{
    using Common;
    using Contracts;
    using Menu.MenuCommands;
 
    /// <summary>
    /// Show on user game rules.
    /// </summary>
    public class ShowGameRulesCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowGameRulesCommand"/> class.
        /// </summary>
        /// <param name="ui">IUI that prints massages.</param>
        public ShowGameRulesCommand(IUI ui)
            : base(ui)
        {
        }

        /// <summary>
        /// Executes show rules command and shows game's rules.
        /// </summary>
        public override void Execute()
        {
            this.UI.Print(Messages.RulesInfo);
            this.UI.ReadKey();
        }
    }
}
