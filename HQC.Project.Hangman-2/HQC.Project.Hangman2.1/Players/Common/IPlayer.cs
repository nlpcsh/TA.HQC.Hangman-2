// <copyright file="IPlayer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Players.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// ???
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// ???
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        int Lives { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        string Word { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        ISet<char> WrongLetters { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        string HiddenWord { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="otherPlayer">???</param>
        /// <returns>???</returns>
        int Compare(IPlayer otherPlayer);
    }
}
