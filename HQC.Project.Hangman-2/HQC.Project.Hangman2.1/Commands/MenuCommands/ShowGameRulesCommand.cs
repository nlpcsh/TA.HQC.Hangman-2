namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;

    public class ShowGameRulesCommand : HQC.Project.Hangman2._1.MenuCommand
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
