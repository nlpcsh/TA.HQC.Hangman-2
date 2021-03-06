﻿// <copyright file="FileExporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Exporters
{
    using System.IO;
    using System.Linq;
    using Common;
    using Importers;

    /// <summary>
    /// Responsible for exporting data in file.
    /// </summary>
    public class FileExporter : IExporter
    {
        private ImportTopPlayersFromFile players;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileExporter"/> class.
        /// </summary>
        /// <param name="players">Players with top scores that have to be written in file.</param>
        public FileExporter(ImportTopPlayersFromFile players)
        {
            this.players = players;
        }

        /// <summary>
        /// Order players descending by their scores and saves them in file.
        /// </summary>
        /// <param name="filename">Path to file.</param>
        public void Save(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                var sortedScores = this.players.TopPlayers.OrderByDescending(x => x.Score);

                foreach (var score in sortedScores)
                {
                    if (score == null)
                    {
                        writer.WriteLine(Globals.FreePositionInScoreBoars);
                    }
                    else
                    {
                        writer.WriteLine(score.Name + "^" + score.Score);
                    }
                }
            }
        }
    }
}
