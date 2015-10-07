// <copyright file="State.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States.Common
{
    using HQC.Project.Hangman;

    /// <summary>
    /// Represents state of the game
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// Play command for game start
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public abstract void Play(HangmanGame game);
    }
}
