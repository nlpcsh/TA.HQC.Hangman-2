// <copyright file="EndGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.GameLogic;
    using HQC.Project.Hangman.GameLogic.States;
    using HQC.Project.Hangman.GameLogic.States.Common;
    using HQC.Project.Hangman.GameScoreBoard;

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
            game.Logger.PrintMessage(string.Format(Messages.WinGameMessage, game.Player.Score));
            game.Logger.PrintSecretWord(game.Player.HiddenWord);

            ScoreBoard.Instance.PlacePlayerInScoreBoard(game.Player);

            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}