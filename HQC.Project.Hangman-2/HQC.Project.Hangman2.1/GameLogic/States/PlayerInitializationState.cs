// <copyright file="PlayerInitializationState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using HQC.Project.Hangman.GameLogic.States.Common;

    /// <summary>
    /// Initialize player if user don't set name, player name is equal to unknown.
    /// </summary>
    public class PlayerInitializationState : State
    {
        /// <summary>
        /// Initialize player.
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public override void Play(HangmanGame game)
        {
            game.UI.Print("Title", "Title");
            game.UI.Print("GameInit", "GameInit");

            string name = game.UI.ReadLine();
            var playerName = string.IsNullOrWhiteSpace(name) ? "unknown" : name;
            game.Player.Name = playerName;
            game.Player.Score = 50;

            game.State = new ChooseCategoryState();
            game.State.Play(game);
        }
    }
}
