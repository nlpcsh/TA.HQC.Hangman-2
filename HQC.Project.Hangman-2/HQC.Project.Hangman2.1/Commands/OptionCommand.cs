namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;

    public class OptionCommand : Command
    {
        public OptionCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.Logger.PrintOptionsMessage();
        }
    }
}
