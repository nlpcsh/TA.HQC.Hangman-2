// <copyright file="Hangman.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.Commands.MenuCommands;
    using HQC.Project.Hangman2.GameStates;
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

            while (true)
            {
                Console.Clear();
                logger.PrintMenu();

                string commandToExecute = Console.ReadLine().Trim().ToLower();

                if (Globals.MenuCommandTypes.ContainsKey(commandToExecute))
                {
                    var command = caommandFactory.GetMenuCommand(commandToExecute, logger, Globals.MenuCommandTypes);
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