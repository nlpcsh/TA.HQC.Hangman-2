namespace HQC.Project.Hangman2.Commands.Common
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Commands.Common;

    public class CommandFactory
    {
        public ICommand GetCommand(string commandAsString, GameEngine game)
        {
            var typeCommand = Globals.commandTypes[commandAsString];
            var command = (ICommand)Activator.CreateInstance(typeCommand, game);
            return command;
        }
    }
}
