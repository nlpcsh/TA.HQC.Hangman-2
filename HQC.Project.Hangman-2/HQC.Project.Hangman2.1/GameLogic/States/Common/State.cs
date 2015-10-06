// <copyright file="State.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States.Common
{
    using HQC.Project.Hangman;

    /// <summary>
    /// ???
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public abstract void Play(HangmanGame game);
    }
}
