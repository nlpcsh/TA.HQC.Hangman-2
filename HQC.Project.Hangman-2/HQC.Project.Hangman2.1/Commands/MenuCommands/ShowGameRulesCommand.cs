namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2;

    public class ShowGameRulesCommand : MenuCommand
    {
        public ShowGameRulesCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.Logger.PrintMenuHelpOption();
        }
    }
}
