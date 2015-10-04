﻿namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;

    public class PlayCommand : HQC.Project.Hangman2._1.MenuCommand
    {
        public PlayCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.State = new ChooseCategoryState();
            this.Game.State.Play(this.Game);
        }
    }
}