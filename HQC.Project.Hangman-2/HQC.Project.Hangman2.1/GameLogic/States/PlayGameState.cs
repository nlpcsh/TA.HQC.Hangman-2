// <copyright file="PlayGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
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
                game.CurrentCommand = game.UI.ReadKeyInput();

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
                    game.UI.Print(Messages.WrongInputMessage, "Message");
                }

                game.UI.Print(game.Player.HiddenWord, "SecretWord");
                game.UI.Print(game.Player.WrongLetters);
                game.UI.Print(game.Player.Lives.ToString(), "Lives");
                game.UI.Print((game.CurrentCommand.Length + 2).ToString(), "Clean");

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
