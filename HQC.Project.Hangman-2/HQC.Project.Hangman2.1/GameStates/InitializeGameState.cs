﻿namespace HQC.Project.Hangman2._1.GameStates
{
    using HQC.Project.Hangman;
    using System;

    public class InitializeGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            Console.Clear();
            Printer.PrintGameTitle();
            Printer.PrintGameInitialization();
            string name = Console.ReadLine();
            var playerName = string.IsNullOrWhiteSpace(name) ? "unknown" : name;
            game.WordGuess = new WordGuesser(playerName, 0);

            Console.Clear();
            Printer.PrintGameTitle();
            Printer.PrintVerticalMiddleBorder();
            Printer.PrintHangman(game.WordGuess.Lives);
            
            string word = game.WordSelect.SelectRandomWord("../../Words/words.txt");
            game.WordGuess = new WordGuesser() { Word = word };
            game.WordGuess.InitializationOfGame();

            Printer.PrintUsedLetters(game.WordGuess.WrongLetters);
            Printer.PrintEnterCommandMessage();

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}