// <copyright file="IPlayer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Players.Common
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
        int Mistakes { get; set; }

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
        string HiddenWord { get; }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="supposedChar">???</param>
        /// <returns>???</returns>
        bool InitializationAfterTheGuess(char supposedChar);

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="otherPlayer">???</param>
        /// <returns>???</returns>
        int Compare(IPlayer otherPlayer);
    }
}
