// <copyright file="InitializeGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman;

    /// <summary>
    /// ???
    /// </summary>
    public class InitializeGameState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(HangmanGame game)
        {
            Console.Clear();
            game.WordGuess.Lives = 7;
            game.WordGuess.WrongLetters = new HashSet<char>();
            game.WordGuess.Word = game.WordSelect.SelectRandomWord();

            game.Logger.PrintGameTitle();
            game.Logger.PrintVerticalMiddleBorder();
            game.Logger.PrintHangman(game.WordGuess.Lives);
            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);
            game.Logger.PrintUsedLetters(game.WordGuess.WrongLetters);
            game.Logger.PrintEnterCommandMessage();

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}
