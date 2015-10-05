// <copyright file="ConsoleHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Common
{
    using System;

    /// <summary>
    /// Help for clear the part of console now everything
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="startCol">???</param>
        /// <param name="endCol">???</param>
        /// <param name="row">???</param>
        public static void ClearConsoleInRange(int startCol, int endCol, int row)
        {
            Console.SetCursorPosition(startCol, row);

            for (int col = startCol; col <= endCol; col++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="startCol">???</param>
        /// <param name="endCol">???</param>
        /// <param name="startRow">???</param>
        /// <param name="endRow">???</param>
        public static void ClearConsoleInRange(int startCol, int endCol, int startRow, int endRow)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                ClearConsoleInRange(startCol, endCol, i);
            }
        }
    }
}
