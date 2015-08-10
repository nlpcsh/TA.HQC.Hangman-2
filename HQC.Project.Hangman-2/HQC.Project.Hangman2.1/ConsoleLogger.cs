namespace HQC.Project.Hangman2._1
{
    using HQC.Project.Hangman2._1.Interfaces;
    //using System;

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}