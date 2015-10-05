// <copyright file="RestartGameCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;

    /// <summary>
    /// Restart the game
    /// </summary>
    public class RestartGameCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestartGameCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public RestartGameCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Game.State = new RestartGameState();
            this.Game.State.Play(this.Game);
        }
    }
}
