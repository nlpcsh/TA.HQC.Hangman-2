// <copyright file="IPlayesImporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Importers.Common
{
    using System.Collections.Generic;
    using HQC.Project.Hangman2.Players.Common;

    /// <summary>
    /// ???
    /// </summary>
    public interface IPlayesImporter
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="name">???</param>
        /// <returns>???</returns>
        IList<IPlayer> ImportPlayers(string name);
    }
}
