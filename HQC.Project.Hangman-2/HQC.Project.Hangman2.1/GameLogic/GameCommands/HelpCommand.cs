﻿// <copyright file="HelpCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.GameCommands
{
    using Common;

    /// <summary>
    /// Help command help to user for guess a letter.
    /// </summary>
    public class HelpCommand : GameCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand"/> class.
        /// </summary>
        /// <param name="currentGame">Instance of <see cref="HangmanGame"/> class.</param>
        public HelpCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// Open guess letter to user.
        /// </summary>
        public override void Execute()
        {
            if (this.Game.Player.Score >= Globals.HelpNeededPoints)
            {
                char firstUnrevealedLetter = '$';

                for (int i = 0; i < this.Game.Player.Word.Length; i++)
                {
                    if (this.Game.Player.HiddenWord[i] == '_')
                    {
                        firstUnrevealedLetter = this.Game.Player.Word[i];
                        break;
                    }
                }

                this.Game.CurrentCommand = firstUnrevealedLetter.ToString();
                var command = this.Game.CommandFactory.GetGameCommand("revealGuessedLetters", this.Game, Globals.CommandTypesValue);
                command.Execute();
                this.Game.Player.Score -= Globals.HelpNeededPoints;
                this.Game.UI.Print(string.Format(Messages.RevealLetterMessage, firstUnrevealedLetter), "Message");
                this.Game.UI.Print(this.Game.Player.HiddenWord, "SecretWord");
            }
            else
            {
                this.Game.UI.Print(string.Format(Messages.CantUseHelp, Globals.HelpNeededPoints), "Message");
            }
        }
    }
}
