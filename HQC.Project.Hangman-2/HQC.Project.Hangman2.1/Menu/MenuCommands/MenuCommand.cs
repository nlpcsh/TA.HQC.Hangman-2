// <copyright file="MenuCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Menu.MenuCommands
{
    using HQC.Project.Hangman.Contracts;
    using HQC.Project.Hangman.UI.Common;

    /// <summary>
    /// Represents menu commands
    /// </summary>
    public abstract class MenuCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuCommand"/> class.
        /// </summary>
        /// <param name="logger">ILogger</param>
        public MenuCommand(ILogger logger)
        {
            this.Logger = logger;
        }

        /// <summary>
        /// Print massages
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public abstract void Execute();
    }
}
