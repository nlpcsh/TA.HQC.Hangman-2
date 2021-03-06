﻿// <copyright file="ImportTopPlayersFromFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Importers
{
    using System.Collections.Generic;
    using System.IO;

    using Common;
    using Hangman.Common;
    using Players;
    using Players.Common;

    /// <summary>
    /// Import players from file with top players.
    /// </summary>
    public class ImportTopPlayersFromFile : IPlayesImporter
    {
        private IList<IPlayer> topPlayers = new List<IPlayer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportTopPlayersFromFile"/> class.
        /// </summary>
        /// <param name="fileName">Path to file with top players.</param>
        public ImportTopPlayersFromFile(string fileName)
        {
            this.TopPlayers = this.ImportPlayers(fileName);
        }

        /// <summary>
        /// Collection of <see cref="IPlayer"/>
        /// </summary>
        public IList<IPlayer> TopPlayers { get; set; }

        /// <summary>
        /// Reads file with top players and add entries in collection of players.
        /// </summary>
        /// <param name="fileName">Path to file with top players.</param>
        /// <returns>Return collection with top players.</returns>
        public IList<IPlayer> ImportPlayers(string fileName)
        {
            var scoreBoardTable = new Player[Globals.ScoreBoardSize];

            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    var score = reader.ReadLine();
                    var index = 0;

                    while (score != null)
                    {
                        string playerName;
                        int playerScore;

                        if (score == Globals.FreePositionInScoreBoars)
                        {
                            playerName = "No Player";
                            playerScore = int.MaxValue;
                        }
                        else
                        {
                            var separateScore = score.Split('^');
                            playerName = separateScore[0].Trim();

                            if (separateScore.Length == 1)
                            {
                                throw new System.ArgumentException("Score tables format is wrong!");
                            }

                            if (int.TryParse(separateScore[1], out playerScore))
                            {
                                playerScore = int.Parse(separateScore[1]);
                            }
                            else
                            {
                                throw new System.ArgumentException("Score is not a number!");
                            }
                        }

                        scoreBoardTable[index] = new Player(playerName, playerScore);
                        score = reader.ReadLine();
                        index++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Top score file is not present!");
            }
            
            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (scoreBoardTable[i] == null)
                {
                    scoreBoardTable[i] = new Player(Globals.NoPlayer, int.MaxValue);
                }
            }

            return scoreBoardTable;
        }
    }
}
