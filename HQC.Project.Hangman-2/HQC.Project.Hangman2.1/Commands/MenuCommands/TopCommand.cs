namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;

    public class TopCommand : MenuCommand
    {
        public TopCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.Scores.LogLine(string.Empty);
            ScoreBoard.Instance.LoadTopPlayers(Globals.BestScoresPath);

            this.Game.Logger.PrintBestScores(ScoreBoard.Instance.ScoreBoardTable.TopPlayers);
        }
    }
}
