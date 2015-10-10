// <copyright file="HangmanStartPoint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using Contracts;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI;
 
    /// <summary>
    /// Start point to the game
    /// </summary>
    public class HangmanStartPoint
    {
        /// <summary>
        /// Prepares console, print menu, take command from user, check if is right and execute it.
        /// </summary>
        /// <param name="console">ILogger that prints massages.</param>
        /// <param name="commandFactory">Command to execute.</param>
        public static void Start(IUI console, CommandFactory commandFactory)
        {
            console.Initialize();

            while (true)
            {
                console.ReInitizlize();

                string commandToExecute = console.ReadLine();  

                if (Globals.MenuCommandTypesValue.ContainsKey(commandToExecute))
                {
                    var command = commandFactory.GetMenuCommand(commandToExecute, console, Globals.MenuCommandTypesValue);
                    command.Execute();
                }
                else
                {
                    console.Print(Messages.WrongMessage, "Message");
                }
            }
        }

        /// <summary>
        /// Entry point
        /// </summary>
        internal static void Main()
        {
            Start(new ConsoleUI(), new CommandFactory());
        }
    }
}