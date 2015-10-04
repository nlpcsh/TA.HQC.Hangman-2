namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Collections.Generic;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands;
    using HQC.Project.Hangman2.Common;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman.Common;

    public class PlayGameState : State
    {
        public override void Play(GameEngine game)
        {
            while (game.WordGuess.HiddenWord.Contains("_"))
            {
                string commandToExecute = game.Execute.ReadInput().ToLower();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    game.WordGuess.InitializationAfterTheGuess(supposedChar);
                }
                else if (commandToExecute == game.WordGuess.Word)
                {
                    game.State = new EndGameState();
                    game.State.Play(game);
                }
                else if (Globals.CommandTypes.ContainsKey(commandToExecute))
                {
                    var command = game.CommandFactory.GetCommand(commandToExecute, game);
                    command.Execute();
                }
                else
                {
                    game.Logger.PrintMessage("Wrong input, please try again!");
                    game.WordGuess.Mistakes++;
                    game.WordGuess.Lives--;
                }

                game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);
                game.Logger.PrintUsedLetters(game.WordGuess.WrongLetters);
                game.Logger.PrintHangman(game.WordGuess.Lives);

                ConsoleHelper.ClearConsoleInRange(Globals.LeftPositionCommandInput, Globals.LeftPositionCommandInput + commandToExecute.Length, Globals.TopPositionCommandInput);
                ConsoleHelper.ClearConsoleInRange(Console.WindowWidth / 2 + 1, Console.WindowWidth - 1, Globals.TopPositionCommandInput + 2);

                if (game.WordGuess.Lives == 0)
                {
                    break;
                }
            }

            game.State = new EndGameState();
            game.State.Play(game);
        }
    }
}
