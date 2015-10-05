// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class PlayGameState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(HangmanGame game)
        {
            while (game.WordGuess.HiddenWord.Contains("_"))
            {
                string commandToExecute = game.Logger.ReadInput();

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
                else if (Globals.CommandTypesValue.ContainsKey(commandToExecute))
                {
                    var command = game.CommandFactory.GetGameCommand(commandToExecute, game, Globals.CommandTypesValue);
                    command.Execute();
                }
                else
                {
                    game.Logger.PrintMessage("Wrong input, please try again!");
                }

                game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);
                game.Logger.PrintUsedLetters(game.WordGuess.WrongLetters);
                game.Logger.PrintHangman(game.WordGuess.Lives);

                ConsoleHelper.ClearConsoleInRange(Globals.leftPositionCommandInput, Globals.leftPositionCommandInput + commandToExecute.Length, Globals.topPositionCommandInput);
                ConsoleHelper.ClearConsoleInRange((Console.WindowWidth / 2) + 1, Console.WindowWidth - 1, Globals.topPositionCommandInput + 2);

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
