namespace HQC.Project.Hangman2._1.Commands
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;

    public class ExitCommand : Command
    {
        public ExitCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            Console.Clear();
            Printer.PrintGameTitle();
            Printer.PrintGoodBuyMessage();
            Environment.Exit(0);
        }
    }
}
