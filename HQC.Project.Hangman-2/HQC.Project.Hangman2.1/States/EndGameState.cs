// <copyright file="EndGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class EndGameState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(HangmanGame game)
        {
            game.Logger.PrintMessage(string.Format(Messages.WinGameMessage, game.WordGuess.Score));
            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);

            ScoreBoard.Instance.PlacePlayerInScoreBoard(game.WordGuess);

            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}