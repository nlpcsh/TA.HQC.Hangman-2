// <copyright file="MenuCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;

    /// <summary>
    /// ???
    /// </summary>
    public abstract class MenuCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuCommand"/> class.
        /// </summary>
        /// <param name="game">???</param>
        public MenuCommand(GameEngine game)
            : base(game)
        {
        }
    }
}
