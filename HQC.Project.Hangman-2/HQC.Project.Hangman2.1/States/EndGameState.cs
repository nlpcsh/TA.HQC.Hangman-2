// <copyright file="EndGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using HQC.Project.Hangman;

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
            game.Logger.PrintMessage(string.Format("You won with {0} mistakes.", game.WordGuess.Mistakes));
            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);

            // game.Scores.PlacePlayerInScoreBoard(game.WordGuess);
            ScoreBoard.Instance.PlacePlayerInScoreBoard(game.WordGuess);
            game.WordGuess.Mistakes = 0;

            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}