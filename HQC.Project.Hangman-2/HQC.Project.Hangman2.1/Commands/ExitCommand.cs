namespace HQC.Project.Hangman2.Commands
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;

    public class ExitCommand : Command
    {
        public ExitCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            Console.Clear();
            this.Game.Logger.PrintGameTitle();
            this.Game.Logger.PrintGoodBuyMessage();
            Environment.Exit(0);
        }
    }
}
