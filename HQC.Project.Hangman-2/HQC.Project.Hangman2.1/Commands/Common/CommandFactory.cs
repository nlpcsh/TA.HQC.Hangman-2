namespace HQC.Project.Hangman2.Commands.Common
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Commands.Common;
    using System.Collections.Generic;

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
