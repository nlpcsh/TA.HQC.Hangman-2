// <copyright file="RestartGameCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.GameCommands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.GameLogic.GameCommands;
    using HQC.Project.Hangman.GameLogic.States;
    using HQC.Project.Hangman2.GameStates;

    /// <summary>
    /// Restart the game.
    /// </summary>
    public class RestartGameCommand : GameCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestartGameCommand"/> class.
        /// </summary>
        /// <param name="currentGame">Instance of <see cref="HangmanGame"/> class.</param>
        public RestartGameCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// Restart game for user.
        /// </summary>
        public override void Execute()
        {
            this.Game.State = new RestartGameState();
            this.Game.State.Play(this.Game);
        }
    }
}
