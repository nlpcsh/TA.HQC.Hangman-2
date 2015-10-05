// <copyright file="Command.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands.Common
{
    using HQC.Project.Hangman;

    /// <summary>
    /// This is the base abstract class for all commands.
    /// </summary>
    public abstract class GameCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public GameCommand(HangmanGame currentGame)
        {
            this.Game = currentGame;
        }

        /// <summary>
        /// ???
        /// </summary>
        protected HangmanGame Game { get;  set; }

        /// <summary>
        /// ???
        /// </summary>
        public abstract void Execute();
    }
}
