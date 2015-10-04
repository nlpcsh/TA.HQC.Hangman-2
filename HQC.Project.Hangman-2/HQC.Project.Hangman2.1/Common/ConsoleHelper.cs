namespace HQC.Project.Hangman2.Common
{
    using System;

    public static class ConsoleHelper
    {
        public static void ClearConsoleInRange(int startCol, int endCol, int row)
        {
            Console.SetCursorPosition(startCol, row);

            for (int col = startCol; col <= endCol; col++)
            {
                Console.Write(" ");
            }
        }

        public static void ClearConsoleInRange(int startCol, int endCol, int startRow, int endRow)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                ClearConsoleInRange(startCol, endCol, i);
            }
        }
    }
}
