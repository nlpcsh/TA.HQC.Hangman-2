﻿namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;
    using HQC.Project.Hangman2._1.GameStates;

    public class PlayCommand : Command
    {
        public PlayCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.State = new InitializeGameState();
            this.Game.State.Play(this.Game);
        }
    }
}