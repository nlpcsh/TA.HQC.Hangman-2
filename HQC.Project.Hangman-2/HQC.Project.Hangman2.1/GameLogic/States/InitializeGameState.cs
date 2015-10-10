// <copyright file="InitializeGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using System.Collections.Generic;

    using HQC.Project.Hangman.GameLogic.States.Common;

    /// <summary>
    /// State of game when put initial lives to player and select new play word
    /// </summary>
    public class InitializeGameState : State
    {
        /// <summary>
        /// Put initial lives to player and select new play word
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public override void Play(HangmanGame game)
        {
            game.Player.Lives = 7;
            game.Player.WrongLetters = new HashSet<char>();
            game.Player.Word = game.WordSelect.SelectRandomWord();
            game.Player.HiddenWord = new string('_', game.Player.Word.Length);

            game.UI.Print("Title", "Title");
            game.UI.Print("|", "MiddleBorder");
            game.UI.Print(game.Player.Lives.ToString(), "Lives");
            game.UI.Print(game.Player.HiddenWord, "SecretWord");
            game.UI.Print(game.Player.WrongLetters);
            game.UI.Print(string.Empty, "EnterCommand");

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}
