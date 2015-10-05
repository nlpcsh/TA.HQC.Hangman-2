namespace HQC.Project.Hangman
{
    using System.IO;
    using System.Linq;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Importers;
    using HQC.Project.Hangman2.Players.Common;

    public sealed class ScoreBoard
    {
        private static ScoreBoard scoreBoardInstance;
        private ImportTopPlayers scoreBoardTable;

        private ScoreBoard()
        {

        }

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


        public ImportTopPlayers ScoreBoardTable
        {
            get
            {
                return this.scoreBoardTable;
            }
        }

        public void LoadTopPlayers(string filename)     
        {
            this.scoreBoardTable = new ImportTopPlayers(filename);
        }

        public void PlacePlayerInScoreBoard(IPlayer player)
        {
            LoadTopPlayers(Globals.BestScoresPath);
            int emptyPosition = this.GetFirstFreePosition();

            if (this.scoreBoardTable.TopPlayers[emptyPosition] == null || player.Mistakes <= this.scoreBoardTable.TopPlayers[emptyPosition].Mistakes)
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

        public void LogLine(string message)
        {
            System.Console.WriteLine(message);
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

        private void SaveScoresToTxtFile()
        {
            using (var writer = new StreamWriter(Globals.BestScoresPath))
            {
                var sortedScores = this.scoreBoardTable.TopPlayers.OrderBy(x => x.Mistakes);

                foreach (var score in sortedScores)
                {
                    if (score == null)
                    {
                        writer.WriteLine(Globals.FreePositionInScoreBoars);
                    }
                    else
                    {
                        writer.WriteLine(score.Name + "-" + score.Mistakes);
                    }
                }
            }
        }
    }
}
