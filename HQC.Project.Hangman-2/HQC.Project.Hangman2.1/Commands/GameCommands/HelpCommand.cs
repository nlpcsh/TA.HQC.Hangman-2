// <copyright file="HelpCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.Common;

    /// <summary>
    /// Help command help to user for guess a letter
    /// </summary>
    public class HelpCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public HelpCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// Open letter to user 
        /// </summary>
        public override void Execute()
        {
            if (Game.WordGuess.Score >= Globals.HelpNeededPoints)
            {
                char firstUnrevealedLetter = '$';

                for (int i = 0; i < this.Game.WordGuess.Word.Length; i++)
                {
                    if (this.Game.WordGuess.HiddenWord[i] == '_')
                    {
                        firstUnrevealedLetter = this.Game.WordGuess.Word[i];
                        break;
                    }
                }

                this.Game.WordGuess.InitializationAfterTheGuess(firstUnrevealedLetter);
                this.Game.WordGuess.Score -= Globals.HelpNeededPoints;
                this.Game.Logger.PrintMessage(string.Format(Messages.RevealLetterMessage, firstUnrevealedLetter));
                this.Game.Logger.PrintSecretWord(this.Game.WordGuess.HiddenWord);
            }
            else
            {
                this.Game.Logger.PrintMessage(string.Format(Messages.CantUseHelp, Globals.HelpNeededPoints));
            }
        }
    }
}
