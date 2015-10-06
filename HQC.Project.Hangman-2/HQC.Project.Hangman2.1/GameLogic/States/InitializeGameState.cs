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
            game.Player.Lives = 7;
            game.Player.WrongLetters = new HashSet<char>();
            game.Player.Word = "array"; //game.WordSelect.SelectRandomWord();
            game.Player.HiddenWord = new string('_', game.Player.Word.Length);

            game.Logger.PrintGameTitle();
            game.Logger.PrintVerticalMiddleBorder();
            game.Logger.PrintHangman(game.Player.Lives);
            game.Logger.PrintSecretWord(game.Player.HiddenWord);
            game.Logger.PrintUsedLetters(game.Player.WrongLetters);
            game.Logger.PrintEnterCommandMessage();

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}
