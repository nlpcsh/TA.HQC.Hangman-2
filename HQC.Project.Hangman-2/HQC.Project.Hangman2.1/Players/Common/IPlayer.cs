// <copyright file="IPlayer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Players.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents abstract player.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Scores.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Lives.
        /// </summary>
        int Lives { get; set; }

        /// <summary>
        /// Word.
        /// </summary>
        string Word { get; set; }

        /// <summary>
        /// Collection of wrong letters.
        /// </summary>
        ISet<char> WrongLetters { get; set; }

        /// <summary>
        /// Hidden word.
        /// </summary>
        string HiddenWord { get; set; }

        /// <summary>
        /// Compares two objects.
        /// </summary>
        /// <param name="otherPlayer">The object with whom compares current object.</param>
        /// <returns>Convention of returned values on comparing(1, 0, -1).</returns>
        int Compare(IPlayer otherPlayer);
    }
}
