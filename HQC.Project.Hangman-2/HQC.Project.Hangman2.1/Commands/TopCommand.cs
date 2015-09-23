namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
using HQC.Project.Hangman2._1.Commands.Common;

    public class TopCommand : Command
    {
        private GameEngine game;
        public TopCommand(GameEngine currentGame)
        {
            this.game = currentGame;
        }

        public override void Execute()
        {
            game.Scores.LogLine(string.Empty);

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (game.Scores.ScoreBoardTable[i] != null && game.Scores.ScoreBoardTable[i].Name != Globals.NoPlayer)
                {
                    game.Scores.LogLine(string.Format("{0}. {1} ---> {2}", i + 1, game.Scores.ScoreBoardTable[i].Name, game.Scores.ScoreBoardTable[i].Mistakes));
                }
                else
                {
                    if (i == 0)
                    {
                        game.Scores.LogLine("No Scores");
                    }

                    break;
                }
            }

            game.Scores.LogLine(string.Empty);
        }
    }
}
