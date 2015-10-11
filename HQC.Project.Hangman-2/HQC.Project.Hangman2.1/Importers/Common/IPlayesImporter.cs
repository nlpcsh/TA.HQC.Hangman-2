// <copyright file="IPlayesImporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Importers.Common
{
    using System.Collections.Generic;
    using Players.Common;

    /// <summary>
    /// Responsible for importing players.
    /// </summary>
    public interface IPlayesImporter
    {
        /// <summary>
        /// Imports players.
        /// </summary>
        /// <param name="name">Place from where data will be imported.</param>
        /// <returns>Collection of <see cref="IPlayer"/> interface.</returns>
        IList<IPlayer> ImportPlayers(string name);
    }
}
