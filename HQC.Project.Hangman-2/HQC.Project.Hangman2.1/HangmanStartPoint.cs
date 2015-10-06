// <copyright file="Hangman.cs" company="PlaceholderCompany">
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
        public static void Start(ILogger logger, CommandFactory commandFactory)
        {
            Console.WindowHeight = Messages.gameTitle.Count + HangmanPattern.Patterns[0].Length + 2;

            while (true)
            {
                Console.Clear();
                logger.Print(Messages.menuOptions);

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

        private static void Main(string[] args)
        {
        }
    }
}