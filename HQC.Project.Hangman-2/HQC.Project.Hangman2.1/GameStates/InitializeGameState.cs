namespace HQC.Project.Hangman2._1.GameStates
{
    using System;
    using HQC.Project.Hangman;

    public class InitializeGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            Console.Clear();

            game.Logger.PrintGameTitle();
            game.Logger.PrintGameInitialization();

            string name = Console.ReadLine();
            var playerName = string.IsNullOrWhiteSpace(name) ? "unknown" : name;
            game.WordGuess.Name = playerName;
            game.WordGuess.Mistakes = 0;

            Console.Clear();
            game.Logger.PrintGameTitle();
            game.Logger.PrintVerticalMiddleBorder();
            game.Logger.PrintHangman(game.WordGuess.Lives);

            string word = game.WordSelect.RandomWord;
            //Console.WriteLine(word);
            game.WordGuess.Word = word;
            game.WordGuess.InitializationOfGame();

            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);
            game.Logger.PrintUsedLetters(game.WordGuess.WrongLetters);
            game.Logger.PrintEnterCommandMessage();

            game.State = new PlayGameState();
            game.State.Play(game);
        }
    }
}
