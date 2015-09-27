namespace HQC.Project.Hangman2._1.GameStates
{
    using System;

    using HQC.Project.Hangman;

    public class EndGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            game.Logger.PrintMessage(string.Format("You won with {0} mistakes.", game.WordGuess.Mistakes));
            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);

            //game.WordGuess.Mistakes = game.WordGuess.Mistakes;
            game.Scores.PlacePlayerInScoreBoard(game.WordGuess);
            game.WordGuess.Mistakes = 0;
            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}