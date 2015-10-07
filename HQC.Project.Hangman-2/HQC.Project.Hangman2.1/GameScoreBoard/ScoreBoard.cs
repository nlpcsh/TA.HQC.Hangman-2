// <copyright file="ScoreBoard.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameScoreBoard
{
    using System.IO;
    using System.Linq;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Importers;
    using HQC.Project.Hangman.Importers.Common;
    using HQC.Project.Hangman.Players.Common;
    using HQC.Project.Hangman2._1.Exporters;

    /// <summary>
    /// Holds information about players and their scores. Can't be inherit.
    /// </summary>
    public sealed class ScoreBoard
    {
        private static volatile ScoreBoard scoreBoardInstance;
        private static object syncLock = new object();
        private ImportTopPlayersFromFile scoreBoardTable;
        private IExporter export;

        private ScoreBoard()
        {
        }

        /// <summary>
        /// Creates only one instance of class. This is implementation of Singleton Pattern.
        /// </summary>
        public static ScoreBoard Instance
        {
            get
            {
                if (scoreBoardInstance == null)
                {
                    lock (syncLock)
                    {
                        if (scoreBoardInstance == null)
                        {
                            scoreBoardInstance = new ScoreBoard(); 
                        }
                    }               
                }

                return scoreBoardInstance;
            }
        }

        /// <summary>
        /// Gets players with top scores. Can not set them via property.
        /// </summary>
        public ImportTopPlayersFromFile ScoreBoardTable
        {
            get
            {
                return this.scoreBoardTable;
            }
        }

        /// <summary>
        /// Takes players with best scores from file. 
        /// </summary>
        /// <param name="filename">Path to file.</param>
        public void LoadTopPlayers(string filename)
        {
            this.scoreBoardTable = new ImportTopPlayersFromFile(filename);
        }

        /// <summary>
        /// Puts current player in score board. Determines position comparing player's scores with other entries in score board.
        /// </summary>
        /// <param name="player">Current players that plays the game.</param>
        public void PlacePlayerInScoreBoard(IPlayer player)
        {
            this.LoadTopPlayers(Globals.BestScoresPath);
            int emptyPosition = this.GetFirstFreePosition();

            if (this.scoreBoardTable.TopPlayers[emptyPosition] == null || player.Score <= this.scoreBoardTable.TopPlayers[emptyPosition].Score)
            {
                this.scoreBoardTable.TopPlayers[emptyPosition] = player;

                for (int i = emptyPosition; i > 0; i--)
                {
                    IPlayer firstPlayer = this.scoreBoardTable.TopPlayers[i];
                    IPlayer secondPlayer = this.scoreBoardTable.TopPlayers[i - 1];

                    if (firstPlayer.Compare(secondPlayer) < 0)
                    {
                        this.scoreBoardTable.TopPlayers[i] = secondPlayer;
                        this.scoreBoardTable.TopPlayers[i - 1] = firstPlayer;
                    }
                }
            }

            this.export = new FileExporter(this.scoreBoardTable);
            this.export.Save(Globals.BestScoresPath);
        }

        private int GetFirstFreePosition()
        {
            int freePosition = Globals.LastPositionInScoreBoard;

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (this.scoreBoardTable.TopPlayers[i].Name == Globals.NoPlayer)
                {
                    freePosition = i;
                    break;
                }
            }

            return freePosition;
        }
    }
}
