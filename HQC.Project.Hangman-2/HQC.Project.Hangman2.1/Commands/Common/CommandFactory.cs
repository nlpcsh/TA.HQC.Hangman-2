// <copyright file="CommandFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands.Common
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman;

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
        public ICommand GetCommand(string commandAsString, HangmanGame game, IDictionary<string, Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, game);
            return command;
        }
    }
}
