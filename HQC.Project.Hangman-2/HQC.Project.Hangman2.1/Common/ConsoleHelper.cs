namespace HQC.Project.Hangman2._1.Common
{
    using System;

    public static class ConsoleHelper
    {
        public static void ClearConsoleInRange(int startCol, int endCol, int row)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                Console.SetCursorPosition(col, row);
                Console.WriteLine(" ");
            }
        }
    }
}
