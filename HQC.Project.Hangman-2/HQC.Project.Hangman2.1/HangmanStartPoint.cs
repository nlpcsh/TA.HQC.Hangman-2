// <copyright file="HangmanStartPoint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using System;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman.UI.Common;

    /// <summary>
    /// Start point to the game
    /// </summary>
    public class HangmanStartPoint
    {
        /// <summary>
        /// Prepares console, print menu, take command from user, check if is right and execute it.
        /// </summary>
        /// <param name="logger">ILogger that prints massages.</param>
        /// <param name="commandFactory">Command to execute.</param>
        public static void Start(ILogger logger, CommandFactory commandFactory)
        {
            Console.WindowHeight = Messages.GameTitle.Count + HangmanPattern.Patterns[0].Length + 2;

            while (true)
            {
                Console.Clear();
                logger.Print(Messages.MenuOptions);

                string commandToExecute = Console.ReadLine().Trim().ToLower();

                if (Globals.MenuCommandTypesValue.ContainsKey(commandToExecute))
                {
                    var command = commandFactory.GetMenuCommand(commandToExecute, logger, Globals.MenuCommandTypesValue);
                    command.Execute();
                }
                else
                {
                    logger.PrintMessage("Wrong command!");
                }
            }
        }

        /// <summary>
        /// Entry point
        /// </summary>
        internal static void Main()
        {
            Start(new ConsoleLogger(), new CommandFactory());
        }
    }
}