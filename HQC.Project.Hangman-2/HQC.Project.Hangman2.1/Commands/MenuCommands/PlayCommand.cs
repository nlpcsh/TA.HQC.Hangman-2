// <copyright file="PlayCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;

    /// <summary>
    /// ???
    /// </summary>
    public class PlayCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public PlayCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Game.State = new PlayerInitializationState();
            this.Game.State.Play(this.Game);
        }
    }
}
