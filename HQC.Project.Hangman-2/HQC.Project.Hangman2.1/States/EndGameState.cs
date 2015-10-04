namespace HQC.Project.Hangman2.GameStates
{
    using System;

    using HQC.Project.Hangman;

    public class EndGameState : State
    {
        public override void Play(GameEngine game)
        {
            game.Logger.PrintMessage(string.Format("You won with {0} mistakes.", game.WordGuess.Mistakes));
            game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);

            //game.Scores.PlacePlayerInScoreBoard(game.WordGuess);
            ScoreBoard.Instance.PlacePlayerInScoreBoard(game.WordGuess);
            game.WordGuess.Mistakes = 0;

            game.State = new RestartGameState();
            game.State.Play(game);
        }
    }
}