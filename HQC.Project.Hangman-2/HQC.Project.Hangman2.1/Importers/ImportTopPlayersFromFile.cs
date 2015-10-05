// <copyright file="ImportTopPlayers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Importers
{
    using System.Collections.Generic;
    using System.IO;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman2.Importers.Common;
    using HQC.Project.Hangman2.Players.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class ImportTopPlayersFromFile : IPlayesImporter
    {
        private IList<IPlayer> topPlayers = new List<IPlayer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportTopPlayersFromFile"/> class.
        /// </summary>
        /// <param name="fileName">???</param>
        public ImportTopPlayersFromFile(string fileName)
        {
            this.TopPlayers = this.ImportPlayers(fileName);
        }

        /// <summary>
        /// ???
        /// </summary>
        public IList<IPlayer> TopPlayers { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="fileName">???</param>
        /// <returns>???</returns>
        public IList<IPlayer> ImportPlayers(string fileName)
        {
            var scoreBoardTable = new Player[Globals.ScoreBoardSize];
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
                        var separateScore = score.Split('-');
                        playerName = separateScore[0].Trim();
                        playerScore = int.Parse(separateScore[1]);
                    }

                    scoreBoardTable[index] = new Player(playerName, playerScore);
                    score = reader.ReadLine();
                    index++;
                }
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
