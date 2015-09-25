namespace HQC.Project.Hangman2._1.GameStates
{
    using System;
    using HQC.Project.Hangman;

    public class InitializeGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            Console.Clear();
            Printer.PrintGameTitle();
            Printer.PrintGameInitialization();
            string name = Console.ReadLine();
            var playerName = string.IsNullOrWhiteSpace(name) ? "unknown" : name;
            //game.WordGuess.Name = playerName;
            //game.WordGuess = new WordGuesser(playerName, 0);
            game.WordGuess.Name = playerName;
            game.WordGuess.Mistakes = 0;

            Console.Clear();
            Printer.PrintGameTitle();
            Printer.PrintVerticalMiddleBorder();
            Printer.PrintHangman(game.WordGuess.Lives);

            string word = game.WordSelect.RandomWord;
            Console.WriteLine(word);
            game.WordGuess.Word = word;
            //game.WordGuess = new WordGuesser() { Word = word };
            game.WordGuess.InitializationOfGame();

            Printer.PrintUsedLetters(game.WordGuess.WrongLetters);
            Printer.PrintEnterCommandMessage();

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}
