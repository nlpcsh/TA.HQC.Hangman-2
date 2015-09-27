namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using HQC.Project.Hangman;
    using System.Collections.Generic;

    public class InitializeGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            Console.Clear();
            game.WordGuess.Lives = 7;
            game.WordGuess.AllGuessedLetters = new List<char>();
            game.WordGuess.WrongLetters = new HashSet<char>();
            game.WordGuess.Word = game.WordSelect.SelectRandomWord();

            game.Logger.PrintGameTitle();
            game.Logger.PrintVerticalMiddleBorder();
            game.Logger.PrintHangman(game.WordGuess.Lives);

            game.WordGuess.InitializationOfGame();

            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);
            game.Logger.PrintUsedLetters(game.WordGuess.WrongLetters);
            game.Logger.PrintEnterCommandMessage();

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}
