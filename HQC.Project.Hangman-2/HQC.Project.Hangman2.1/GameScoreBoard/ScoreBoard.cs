namespace HQC.Project.Hangman
{
    using System.IO;
    using System.Linq;

    using System.Collections.Generic;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Players.Common;
    using HQC.Project.Hangman2.Importers;

    public sealed class ScoreBoard 
    {
        private static ScoreBoard scoreBoardInstance;
        private ImportTopPlayers scoreBoardTable;
        //private ILogger message;

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
            //this.scoreBoard = new TopPlayers(@"..\..\bestScores.txt");
            this.scoreBoardTable = new ImportTopPlayers(filename);
            //return this.scoreBoardTable;
        }
        public void PlacePlayerInScoreBoard(IPlayer player)
        {
            //this.scoreBoard = new TopPlayers(@"..\..\bestScores.txt");
            LoadTopPlayers(@"..\..\bestScores.txt");
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
            using (var writer = new StreamWriter(@"..\..\bestScores.txt"))
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

        //private IList<IPlayer> ReadScoresFromTxtFile()
        //{
        //    var scoreBoardTable = new Player[Globals.ScoreBoardSize];
        //    using (var reader = new StreamReader(@"..\..\bestScores.txt"))
        //    {
        //        var score = reader.ReadLine();
        //        var index = 0;

        //        while (score != null)
        //        {
        //            string playerName;
        //            int playerScore;

        //            if (score == Globals.FreePositionInScoreBoars)
        //            {
        //                playerName = "No Player";
        //                playerScore = int.MaxValue;
        //            }
        //            else
        //            {
        //                var separateScore = score.Split('-');
        //                playerName = separateScore[0].Trim();
        //                playerScore = int.Parse(separateScore[1]);
        //            }

        //            scoreBoardTable[index] = new Player(playerName, playerScore);
        //            score = reader.ReadLine();
        //            index++;
        //        }
        //    }

        //    for (int i = 0; i < Globals.ScoreBoardSize; i++)
        //    {
        //        if (scoreBoardTable[i] == null)
        //        {
        //            scoreBoardTable[i] = new Player(Globals.NoPlayer, int.MaxValue);
        //        }
        //    }

        //    return scoreBoardTable;
        //}
    }
}
