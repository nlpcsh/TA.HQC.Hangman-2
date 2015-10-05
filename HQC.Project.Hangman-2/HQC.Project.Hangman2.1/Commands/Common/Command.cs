// <copyright file="Command.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands.Common
{
    using HQC.Project.Hangman;

    /// <summary>
    /// This is the base abstract class for all commands.
    /// </summary>
    public abstract class Command : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public Command(GameEngine currentGame)
        {
            this.Game = currentGame;
        }

        /// <summary>
        /// ???
        /// </summary>
        protected GameEngine Game { get;  set; }

        /// <summary>
        /// ???
        /// </summary>
        public abstract void Execute();
    }
}
