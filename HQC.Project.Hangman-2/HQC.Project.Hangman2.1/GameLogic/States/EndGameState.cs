// <copyright file="EndGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameStates
{
    using Common;
    using GameLogic;
    using GameLogic.States;
    using GameLogic.States.Common;
    using GameScoreBoard;

    /// <summary>
    /// Represents end game state
    /// </summary>
    public class EndGameState : State
    {
        /// <summary>
        /// Save player score and change game state to restart.
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public override void Play(HangmanGame game)
        {
            game.UI.Print(string.Format(Messages.WinGameMessage, game.Player.Score), "Message");
            game.UI.Print(game.Player.HiddenWord, "SecretWord");

            ScoreBoard.Instance.PlacePlayerInScoreBoard(game.Player);

            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}