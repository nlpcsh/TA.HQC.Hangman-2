namespace HQC.Project.Hangman2
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;

    public abstract class MenuCommand : Command
    {
        public MenuCommand(GameEngine game)
            : base(game)
        {
        }
    }
}
