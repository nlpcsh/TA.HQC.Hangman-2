// <copyright file="ExitCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Commands
{
    using Contracts;
    using Menu.MenuCommands;

    /// <summary>
    /// Exit the game.
    /// </summary>
    public class ExitCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        /// <param name="ui">IUI that prints massages.</param>
        public ExitCommand(IUI ui)
            : base(ui)
        {
        }

        /// <summary>
        /// Print good buy message to user and end the game.
        /// </summary>
        public override void Execute()
        {
            this.UI.Print("GoodBuy", "GoodBuy");
            System.Environment.Exit(0);
        }
    }
}
