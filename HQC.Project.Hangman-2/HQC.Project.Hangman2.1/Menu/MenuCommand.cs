// <copyright file="MenuCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Menu.MenuCommands
{
    using HQC.Project.Hangman.Contracts;

    /// <summary>
    /// Represents menu commands
    /// </summary>
    public abstract class MenuCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuCommand"/> class.
        /// </summary>
        /// <param name="ui">IUI</param>
        public MenuCommand(IUI ui)
        {
            this.UI = ui;
        }

        /// <summary>
        /// Print massages
        /// </summary>
        public IUI UI { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public abstract void Execute();
    }
}
