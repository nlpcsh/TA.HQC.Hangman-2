namespace HQC.Project.Hangman2.Commands
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2._1;

    public class ExitCommand : MenuCommand
    {
        public ExitCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.Logger.PrintGoodBuyMessage();
            Environment.Exit(0);
        }
    }
}
