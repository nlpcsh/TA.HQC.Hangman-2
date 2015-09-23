namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
using HQC.Project.Hangman2._1.Commands.Common;

    public class OptionCommand : Command
    {
        private GameEngine game;

        public OptionCommand(GameEngine currentGame)
        {
            this.game = currentGame;
        }

        public override void Execute()
        {
            Printer.PrintOptionsMessage();
        }
    }
}
