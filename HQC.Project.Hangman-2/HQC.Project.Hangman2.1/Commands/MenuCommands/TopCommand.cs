namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Commands.Common;

    public class TopCommand : HQC.Project.Hangman2._1.MenuCommand
    {
        public TopCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.Scores.LogLine(string.Empty);
            ScoreBoard.Instance.LoadTopPlayers(@"..\..\bestScores.txt");
            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {             
                if (ScoreBoard.Instance.ScoreBoardTable.TopPlayers[i] != null && ScoreBoard.Instance.ScoreBoardTable.TopPlayers[i].Name != Globals.NoPlayer)
                {
                    this.Game.Scores.LogLine(string.Format("{0}. {1} ---> {2}", i + 1, ScoreBoard.Instance.ScoreBoardTable.TopPlayers[i].Name, ScoreBoard.Instance.ScoreBoardTable.TopPlayers[i].Mistakes));
                }
                else
                {
                    if (i == 0)
                    {
                        this.Game.Scores.LogLine("No Scores");
                    }

                    break;
                }
            }

            this.Game.Scores.LogLine(string.Empty);
        }
    }
}
