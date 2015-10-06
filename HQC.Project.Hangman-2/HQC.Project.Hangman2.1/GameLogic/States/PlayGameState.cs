// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Linq;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Common;
    using HQC.Project.Hangman2.Players.Common;

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
                // string commandToExecute = game.Logger.ReadInput();
                game.CurrentCommand = game.Logger.ReadInput();

                if (game.CurrentCommand.Length == 1)
                {
                    char supposedChar = game.CurrentCommand[0];
                    //game.WordGuess.InitializationAfterTheGuess(supposedChar);
                    var command = game.CommandFactory.GetGameCommand("revealGuessedLetters", game, Globals.CommandTypesValue);
                    command.Execute();
                }
                else if (game.CurrentCommand == game.WordGuess.Word)
                {
                    var bonus = GetBonus(game.WordGuess);

                    game.WordGuess.Score += bonus;

                    game.State = new EndGameState();
                    game.State.Play(game);
                }
                else if (Globals.CommandTypesValue.ContainsKey(game.CurrentCommand))
                {
                    var command = game.CommandFactory.GetGameCommand(game.CurrentCommand, game, Globals.CommandTypesValue);
                    command.Execute();
                }
                else
                {
                    game.Logger.PrintMessage("Wrong input, please try again!");
                }

                game.Logger.PrintSecretWord(game.WordGuess.HiddenWord);
                game.Logger.PrintUsedLetters(game.WordGuess.WrongLetters);
                game.Logger.PrintHangman(game.WordGuess.Lives);

                ConsoleHelper.ClearConsoleInRange(Globals.leftPositionCommandInput, Globals.leftPositionCommandInput + game.CurrentCommand.Length, Globals.topPositionCommandInput);
                ConsoleHelper.ClearConsoleInRange((Console.WindowWidth / 2) + 1, Console.WindowWidth - 1, Globals.topPositionCommandInput + 2);

                if (game.WordGuess.Lives == 0)
                {
                    break;
                }
            }

            game.State = new EndGameState();
            game.State.Play(game);
        }

        private int GetBonus(IPlayer player)
        {
            var hiddenWords = player.HiddenWord.Count(x => x == '_');
            var bonus = hiddenWords * 10;

            if (hiddenWords >= player.Word.Length / 2)
            {
                return bonus * 2;
            }

            return bonus;
        }
    }
}
