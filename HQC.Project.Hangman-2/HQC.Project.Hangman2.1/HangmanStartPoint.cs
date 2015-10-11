// <copyright file="HangmanStartPoint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using Common;
    using Contracts;
    using UI;
 
    /// <summary>
    /// Start point to the game
    /// </summary>
    public class HangmanStartPoint
    {
        /// <summary>
        /// Prepares console, print menu, take command from user, check if is right and execute it.
        /// </summary>
        /// <param name="ui">IUI that prints massages.</param>
        /// <param name="commandFactory">Command to execute.</param>
        public static void Start(IUI ui, CommandFactory commandFactory)
        {
            ui.Initialize();

            while (true)
            {
                ui.ReInitizlize();

                string commandToExecute = ui.ReadLine();  

                if (Globals.MenuCommandTypesValue.ContainsKey(commandToExecute))
                {
                    var command = commandFactory.GetMenuCommand(commandToExecute, ui, Globals.MenuCommandTypesValue);
                    command.Execute();
                }
                else
                {
                    ui.Print(Messages.WrongMessage, "Message");
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