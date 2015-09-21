using HQC.Project.Hangman;
using HQC.Project.Hangman2._1.Common;
using System;
namespace HQC.Project.Hangman2._1.GameStates
{
    public class PlayGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            //string commandToExecute = string.Empty;
            while (game.WordGuess.HiddenWord.Contains("_"))
            {
                string commandToExecute = game.Execute.ReadInput();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    game.WordGuess.InitializationAfterTheGuess(supposedChar);
                }
                else if (commandToExecute.Equals(Command.Help.ToString().ToLower()))
                {
                    game.WordGuess.RevealTheNextLetter();
                }
                else if (commandToExecute.Equals(Command.Top.ToString().ToLower()))
                {
                    game.Scores.PrintTopResults();
                }
                else if (commandToExecute.Equals(Command.Restart.ToString().ToLower()))
                {
                    // this.Execute.Restart();
                    game.NewGame();
                }
                else if (commandToExecute.Equals(Command.Exit.ToString().ToLower()))
                {
                    // this.Execute.Exit();
                    Printer.PrintGoodBuyMessage();
                    Environment.Exit(0);
                }
                else if (commandToExecute.Equals(Command.Options.ToString().ToLower()))
                {
                    Printer.PrintOptionsMessage();
                }
                else
                {
                    Printer.PrintWrongMessage("Wrong command, please try again!");
                }

                ConsoleHelper.ClearConsoleInRange(Globals.LeftPositionCommandInput, Globals.LeftPositionCommandInput + commandToExecute.Length,
                    Globals.TopPositionCommandInput);
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
