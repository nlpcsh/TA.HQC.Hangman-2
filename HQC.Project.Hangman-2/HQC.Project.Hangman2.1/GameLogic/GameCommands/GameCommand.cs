// <copyright file="GameCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.GameCommands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Contracts;

    /// <summary>
    /// This is the base abstract class for all commands.
    /// </summary>
    public abstract class GameCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameCommand"/> class.
        /// </summary>
        /// <param name="currentGame">Instance of <see cref="HangmanGame"/> class.???</param>
        public GameCommand(HangmanGame currentGame)
        {
            this.Game = currentGame;
        }

        /// <summary>
        /// Property keep instance of HangmanGame
        /// </summary>
        protected HangmanGame Game { get;  set; }

        /// <summary>
        /// Abstract method should implement every inheritance class
        /// </summary>
        public abstract void Execute();
    }
}
