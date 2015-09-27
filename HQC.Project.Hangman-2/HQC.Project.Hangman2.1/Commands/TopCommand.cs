namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Commands.Common;

    public class TopCommand : Command
    {
        public TopCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.Scores.LogLine(string.Empty);

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (this.Game.Scores.ScoreBoardTable[i] != null && this.Game.Scores.ScoreBoardTable[i].Name != Globals.NoPlayer)
                {
                    this.Game.Scores.LogLine(string.Format("{0}. {1} ---> {2}", i + 1, this.Game.Scores.ScoreBoardTable[i].Name, this.Game.Scores.ScoreBoardTable[i].Mistakes));
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
