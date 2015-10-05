namespace HangmanConsoleApp
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;

    class ConsoleApp
    {
        static void Main(string[] args)
        {
            HangmanStartPoint.Start(new ConsoleLogger(), new CommandFactory());
        }
    }
}
