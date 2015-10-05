namespace HQC.Project.Hangman2.Commands.Common
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman;

    public class CommandFactory
    {
        public ICommand GetCommand(string commandAsString, GameEngine game, IDictionary<string, Type> commandTypes)
        {
            var typeCommand = commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, game);
            return command;
        }
    }
}
