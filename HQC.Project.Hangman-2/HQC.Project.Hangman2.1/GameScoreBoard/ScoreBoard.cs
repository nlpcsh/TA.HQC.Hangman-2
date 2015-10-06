// <copyright file="ScoreBoard.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameScoreBoard
{
    using System.IO;
    using System.Linq;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Importers;
    using HQC.Project.Hangman.Players.Common;

    /// <summary>
    /// ???
    /// </summary>
    public sealed class ScoreBoard
    {
        private static ScoreBoard scoreBoardInstance;
        private ImportTopPlayersFromFile scoreBoardTable;

        private ScoreBoard()
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public static ScoreBoard Instance
        {
            get
            {
                if (scoreBoardInstance == null)
                {
                    scoreBoardInstance = new ScoreBoard();
                }

                return scoreBoardInstance;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public ImportTopPlayersFromFile ScoreBoardTable
        {
            get
            {
                return this.scoreBoardTable;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="filename">???</param>
        public void LoadTopPlayers(string filename)
        {
            this.scoreBoardTable = new ImportTopPlayersFromFile(filename);
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="player">???</param>
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

            this.SaveScoresToTxtFile();
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="message">???</param>
      
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

        private void SaveScoresToTxtFile()
        {
            using (var writer = new StreamWriter(Globals.BestScoresPath))
            {
                var sortedScores = this.scoreBoardTable.TopPlayers.OrderBy(x => x.Score);

                foreach (var score in sortedScores)
                {
                    if (score == null)
                    {
                        writer.WriteLine(Globals.FreePositionInScoreBoars);
                    }
                    else
                    {
                        writer.WriteLine(score.Name + "-" + score.Score);
                    }
                }
            }
        }
    }
}
