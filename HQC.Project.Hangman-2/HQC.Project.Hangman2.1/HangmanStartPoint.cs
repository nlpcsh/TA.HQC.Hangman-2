// <copyright file="Hangman.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;
    using Hangman2.Common;
    using System;

    /// <summary>
    /// Start point to the game
    /// </summary>
    public class HangmanStartPoint
    {
        private static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var caommandFactory = new CommandFactory();
            Console.WindowHeight = Globals.gameTitle.Count + HangmanPattern.Patterns[0].Length + 2;

            while (true)
            {
                Console.Clear();
                logger.Print(Globals.menuOptions);

                string commandToExecute = Console.ReadLine().Trim().ToLower();

                if (Globals.MenuCommandTypesValue.ContainsKey(commandToExecute))
                {
                    var command = caommandFactory.GetMenuCommand(commandToExecute, logger, Globals.MenuCommandTypesValue);
                    command.Execute();
                }
                else
                {
                    logger.PrintMessage("Wrong command!");
                }
            }
        }
    }
}