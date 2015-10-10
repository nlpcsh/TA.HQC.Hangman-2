namespace HangmanConsoleApp
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI;

    /// <summary>
    /// Entry point for Console application
    /// </summary>
    public class ConsoleApp
    {
        private static void Main(string[] args)
        {
            HangmanStartPoint.Start(new ConsoleUI(), new CommandFactory());
        }
    }
}
