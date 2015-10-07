// <copyright file="ConsoleHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;

    /// <summary>
    /// Help for clear the part of console now everything
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Clear range of row on console
        /// </summary>
        /// <param name="startCol">From where</param>
        /// <param name="endCol">to where</param>
        /// <param name="row">How many rows</param>
        public static void ClearConsoleInRange(int startCol, int endCol, int row)
        {
            Console.SetCursorPosition(startCol, row);

            for (int col = startCol; col <= endCol; col++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Clean console set limits
        /// </summary>
        /// <param name="startCol">From which collumn</param>
        /// <param name="endCol">To which collumn</param>
        /// <param name="startRow">From which row</param>
        /// <param name="endRow">To which row</param>
        public static void ClearConsoleInRange(int startCol, int endCol, int startRow, int endRow)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                ClearConsoleInRange(startCol, endCol, i);
            }
        }
    }
}
