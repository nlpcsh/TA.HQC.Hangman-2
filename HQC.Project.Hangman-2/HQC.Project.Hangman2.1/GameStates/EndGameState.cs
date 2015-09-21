using HQC.Project.Hangman;
using System;
namespace HQC.Project.Hangman2._1.GameStates
{
    public class EndGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            Printer.PrintWrongMessage(string.Format("You won with {0} mistakes.", game.WordGuess.Mistakes));

            Printer.PrintSecretWord(game.WordGuess.HiddenWord);
            // Console.WriteLine("Please enter your name for the top scoreboard:");
            //string playerName = Console.ReadLine();
            //game.Player.Name = playerName;

            game.WordGuess.Mistakes = game.WordGuess.Mistakes;
            game.Scores.PlacePlayerInScoreBoard(game.WordGuess);
            game.WordGuess.Mistakes = 0;
            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}
