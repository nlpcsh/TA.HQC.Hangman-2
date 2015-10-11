// <copyright file="CommandFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System.Collections.Generic;
    using Contracts;
    using GameLogic;

    /// <summary>
    /// Make easy create command by factory pattern
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// All possible in game command
        /// </summary>
        /// <param name="commandAsString">Command from user</param>
        /// <param name="game">An instance of HangmanGame</param>
        /// <param name="commandTypes">All in game commands</param>
        /// <returns>all possible in game commands</returns>
        public ICommand GetGameCommand(string commandAsString, HangmanGame game, IDictionary<string, System.Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)System.Activator.CreateInstance(typeCommand, game);
            return command;
        }

        /// <summary>
        /// All possible menu game command
        /// </summary>
        /// <param name="commandAsString">Command from user</param>
        /// <param name="ui">Takes UI(where will print data)</param>
        /// <param name="commandTypes">All in menu game commands</param>
        /// <returns>Instance of command</returns>
        public ICommand GetMenuCommand(string commandAsString, IUI ui, IDictionary<string, System.Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)System.Activator.CreateInstance(typeCommand, ui);
            return command;
        }
    }
}
