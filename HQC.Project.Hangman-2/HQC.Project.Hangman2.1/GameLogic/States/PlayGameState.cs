// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using System;
    using System.Linq;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.GameLogic.States.Common;
    using HQC.Project.Hangman.Players.Common;
    using HQC.Project.Hangman2.GameStates;

    /// <summary>
    /// Read and execute player commands while player wins or lose the game.
    /// </summary>
    public class PlayGameState : State
    {
        /// <summary>
        /// Read and execute player commands while player wins or lose the game.
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public override void Play(HangmanGame game)
        {
            while (game.Player.HiddenWord.Contains("_"))
            {
                game.CurrentCommand = game.Logger.ReadInput();

                if (game.CurrentCommand.Length == 1)
                {
                    char supposedChar = game.CurrentCommand[0];
                    var command = game.CommandFactory.GetGameCommand("revealGuessedLetters", game, Globals.CommandTypesValue);
                    command.Execute();
                }
                else if (game.CurrentCommand == game.Player.Word)
                {
                    var bonus = this.GetBonus(game.Player);

                    game.Player.Score += bonus;

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

                game.Logger.PrintSecretWord(game.Player.HiddenWord);
                game.Logger.PrintUsedLetters(game.Player.WrongLetters);
                game.Logger.PrintHangman(game.Player.Lives);

                ConsoleHelper.ClearConsoleInRange(Globals.LeftPositionCommandInput, Globals.LeftPositionCommandInput + game.CurrentCommand.Length, Globals.TopPositionCommandInput);
                ConsoleHelper.ClearConsoleInRange((Console.WindowWidth / 2) + 1, Console.WindowWidth - 1, Globals.TopPositionCommandInput + 2);

                if (game.Player.Lives == 0)
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
