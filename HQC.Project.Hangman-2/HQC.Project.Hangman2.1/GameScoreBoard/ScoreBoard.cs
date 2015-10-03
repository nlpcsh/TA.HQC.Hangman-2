namespace HQC.Project.Hangman
{
    using System.IO;
    using System.Linq;

    using System.Collections.Generic;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Players.Common;

    public sealed class ScoreBoard : ILogger
    {
        private static ScoreBoard scoreBoardInstance;
        private IList<IPlayer> scoreBoardTable = new List<IPlayer>();
        private ILogger logger;

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


        public IList<IPlayer> ScoreBoardTable
        {
            get
            {
                return this.scoreBoardTable;
            }
        }

        public void PlacePlayerInScoreBoard(IPlayer player)
        {
            scoreBoardTable = ReadScoresFromTxtFile();
            int emptyPosition = this.GetFirstFreePosition();

            if (this.scoreBoardTable[emptyPosition] == null || player.Mistakes <= this.scoreBoardTable[emptyPosition].Mistakes)
            {
                this.scoreBoardTable[emptyPosition] = player;

                for (int i = emptyPosition; i > 0; i--)
                {
                    IPlayer firstPlayer = this.scoreBoardTable[i];
                    IPlayer secondPlayer = this.scoreBoardTable[i - 1];

                    if (firstPlayer.Compare(secondPlayer) < 0)
                    {
                        this.scoreBoardTable[i] = secondPlayer;
                        this.scoreBoardTable[i - 1] = firstPlayer;
                    }
                }
            }

            this.SaveScoresToTxtFile();

        }

        public void PrintTopResults()
        {
            // Console.WriteLine();
            //this.LogLine(string.Empty);
            //
            //for (int i = 0; i < Globals.ScoreBoardSize; i++)
            //{
            //    if (this.scoreBoardTable[i] != null && this.scoreBoardTable[i].Name != Globals.NoPlayer)
            //    {
            //        // Console.WriteLine("{0}. {1} ---> {2}", i + 1, this.scoreBoardTable[i].Name, this.scoreBoardTable[i].Mistakes);
            //        this.LogLine(string.Format("{0}. {1} ---> {2}", i + 1, this.scoreBoardTable[i].Name, this.scoreBoardTable[i].Mistakes));
            //    }
            //    else
            //    {
            //        if (i == 0)
            //        {
            //            // Console.WriteLine("No Scores");
            //            this.LogLine("No Scores");
            //        }
            //
            //        break;
            //    }
            //}

            // Console.WriteLine();
            this.LogLine(string.Empty);
        }

        public void LogLine(string printMessage)
        {
            this.logger.LogLine(printMessage);
        }

        private int GetFirstFreePosition()
        {
            int freePosition = Globals.LastPositionInScoreBoard;

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (this.scoreBoardTable[i].Name == Globals.NoPlayer)
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
                var sortedScores = this.scoreBoardTable.OrderBy(x => x.Mistakes);

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

        private IList<IPlayer> ReadScoresFromTxtFile()
        {
            var scoreBoardTable = new Player[Globals.ScoreBoardSize];
            using (var reader = new StreamReader(@"..\..\bestScores.txt"))
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


        public void PrintGameTitle()
        {
            throw new System.NotImplementedException();
        }

        public void PrintOptionsControls()
        {
            throw new System.NotImplementedException();
        }

        public void PrintGoodBuyMessage()
        {
            throw new System.NotImplementedException();
        }

        public void PrintMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public void PrintSecretWord(string hiddenWord)
        {
            throw new System.NotImplementedException();
        }

        public void PrintHangman(int playerLives)
        {
            throw new System.NotImplementedException();
        }

        public void PrintVerticalMiddleBorder()
        {
            throw new System.NotImplementedException();
        }

        public void PrintEnterCommandMessage()
        {
            throw new System.NotImplementedException();
        }

        public void PrintUsedLetters(ISet<char> letters)
        {
            throw new System.NotImplementedException();
        }

        public void PrintGameInitialization()
        {
            throw new System.NotImplementedException();
        }

        public void PrintMenu()
        {
            throw new System.NotImplementedException();
        }

        public void PrintCategories(string[] categories)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
