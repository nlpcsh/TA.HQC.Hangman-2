namespace HQC.Project.Hangman2.GameStates
{
    using System;

    using HQC.Project.Hangman;

    public class PlayerInitializationState : GameState
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

            game.State = new InitializeGameState();
            game.State.Play(game);
        }
    }
}
