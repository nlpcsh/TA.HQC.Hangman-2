namespace HangmanConsoleApp
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI;

    public class ConsoleApp
    {
        public static void Main(string[] args)
        {
            HangmanStartPoint.Start(new ConsoleLogger(), new CommandFactory());
        }
    }
}
