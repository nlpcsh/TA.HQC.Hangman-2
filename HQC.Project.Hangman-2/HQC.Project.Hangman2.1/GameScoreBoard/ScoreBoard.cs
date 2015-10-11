// <copyright file="ScoreBoard.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameScoreBoard
{
    using Common;
    using Exporters;
    using Importers;
    using Players.Common;

    /// <summary>
    /// Holds information about players and their scores. Can't be inherit.
    /// </summary>
    public sealed class ScoreBoard
    {
        private static readonly System.Lazy<ScoreBoard> Lazy = new System.Lazy<ScoreBoard>(() => new ScoreBoard());
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
                return Lazy.Value;
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

            if (this.scoreBoardTable.TopPlayers[emptyPosition] == null || player.Score >= this.scoreBoardTable.TopPlayers[emptyPosition].Score)
            {
                this.scoreBoardTable.TopPlayers[emptyPosition] = player;
                        
                for (int i = 0; i < emptyPosition; i++)
                {
                    IPlayer firstPlayer = this.scoreBoardTable.TopPlayers[i];
                    IPlayer secondPlayer = this.scoreBoardTable.TopPlayers[i + 1];

                    if (firstPlayer.Score < secondPlayer.Score)
                    {
                        this.scoreBoardTable.TopPlayers[i] = secondPlayer;
                        this.scoreBoardTable.TopPlayers[i + 1] = firstPlayer;
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
