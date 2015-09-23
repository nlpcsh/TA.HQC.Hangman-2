namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.Interfaces;

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}