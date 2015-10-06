// <copyright file="CommandFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Contracts;
    using HQC.Project.Hangman.GameLogic;
    using HQC.Project.Hangman.UI.Common;

    /// <summary>
    /// Make easy create command by factory patern
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
        public ICommand GetGameCommand(string commandAsString, HangmanGame game, IDictionary<string, Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, game);
            return command;
        }

        /// <summary>
        /// All possible menu game command
        /// </summary>
        /// <param name="commandAsString">Command from user</param>
        /// <param name="logger">Takes logger(where will print data)</param>
        /// <param name="commandTypes">All in menu game commands</param>
        /// <returns></returns>
        public ICommand GetMenuCommand(string commandAsString, ILogger logger, IDictionary<string, Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, logger);
            return command;
        }
    }
}
