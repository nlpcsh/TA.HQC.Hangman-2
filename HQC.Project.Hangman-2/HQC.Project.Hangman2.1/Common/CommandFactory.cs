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
    /// ???
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="commandAsString">Command from user</param>
        /// <param name="game">???</param>
        /// <param name="commandTypes">All commands that exist</param>
        /// <returns>command</returns>
        public ICommand GetGameCommand(string commandAsString, HangmanGame game, IDictionary<string, Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, game);
            return command;
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="commandAsString">???</param>
        /// <param name="logger">???</param>
        /// <param name="commandTypes">???</param>
        /// <returns></returns>
        public ICommand GetMenuCommand(string commandAsString, ILogger logger, IDictionary<string, Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, logger);
            return command;
        }
    }
}
