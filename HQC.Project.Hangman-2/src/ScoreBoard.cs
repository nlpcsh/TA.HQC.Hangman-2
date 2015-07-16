namespace HQC.Project.Hangman2
{
    using System;
    using System.IO;
    using System.Linq;

    public class ScoreBoard
    {
        private Player[] scoreBoardTable;

        public ScoreBoard()
        {
            this.scoreBoardTable = this.ReadScoresFromTxtFile();
        }

        public void PlacePlayerInScoreBoard(Player player)
        {
            int emptyPosition = GetFirstFreePosition();

            if (scoreBoardTable[emptyPosition] == null || player.Mistakes <= scoreBoardTable[emptyPosition].Mistakes)
            {
                scoreBoardTable[emptyPosition] = player;

                for (int i = emptyPosition; i > 0; i--)
                {
                    Player firstPlayer = scoreBoardTable[i];
                    Player secondPlayer = scoreBoardTable[i - 1];

                    if (firstPlayer.Compare(secondPlayer) < 0)
                    {
                        //// swap
                        scoreBoardTable[i] = secondPlayer;
                        scoreBoardTable[i - 1] = firstPlayer;
                    }
                }
            }

            this.SaveScoresToTxtFile();
        }

        public void PrintTopResults()
        {
            Console.WriteLine();
            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (this.scoreBoardTable[i] != null && this.scoreBoardTable[i].Name != Globals.NoPlayer)
                {
                    Console.WriteLine("{0}. {1} ---> {2}", i + 1, this.scoreBoardTable[i].Name, this.scoreBoardTable[i].Mistakes);
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("No Scores");
                    }

                    break;
                }
            }

            Console.WriteLine();
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

        private Player[] ReadScoresFromTxtFile()
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
    }
}
