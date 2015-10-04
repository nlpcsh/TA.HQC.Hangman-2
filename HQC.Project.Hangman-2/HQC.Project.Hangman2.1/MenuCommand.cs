namespace HQC.Project.Hangman2._1
{
    using System;
    using HQC.Project.Hangman;
    

    public abstract class MenuCommand : HQC.Project.Hangman2.Commands.Common.Command
    {
        public MenuCommand(GameEngine game)
            : base(game)
        {
        }
    }
}
