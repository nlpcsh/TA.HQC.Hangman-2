// <copyright file="StartGameCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.GameCommands
{
    using States;

    /// <summary>
    /// Command for starting the game.
    /// </summary>
    public class StartGameCommand : GameCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartGameCommand"/> class.
        /// </summary>
        /// <param name="currentGame">Instance of <see cref="HangmanGame"/> class.</param>
        public StartGameCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// Start game.
        /// </summary>
        public override void Execute()
        {
            this.Game.State = new InitializeGameState();
            this.Game.State.Play(this.Game);
        }
    }
}