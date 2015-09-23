﻿namespace HQC.Project.Hangman2._1.GameStates
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Common;
    using HQC.Project.Hangman2._1.Commands;
    using System.Collections.Generic;
    using HQC.Project.Hangman2._1.Commands.Common;

    public class PlayGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            while (game.WordGuess.HiddenWord.Contains("_"))
            {
                string commandToExecute = game.Execute.ReadInput();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    game.WordGuess.InitializationAfterTheGuess(supposedChar);

                }
                else if (Globals.commandTypes.ContainsKey(commandToExecute.ToLower()))
                {
                    var typeCommand = Globals.commandTypes[commandToExecute.ToLower()];
                    var command = (ICommand)Activator.CreateInstance(typeCommand, game);
                    command.Execute();
                }
                else
                {
                    Printer.PrintMessage("Wrong input, please try again!");
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
