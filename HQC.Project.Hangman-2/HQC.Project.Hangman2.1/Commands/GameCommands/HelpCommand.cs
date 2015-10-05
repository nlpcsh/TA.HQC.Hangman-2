// <copyright file="HelpCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2;

    /// <summary>
    /// Help command help to user for guess a letter
    /// </summary>
    public class HelpCommand : GameCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public HelpCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
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
            this.Game.Logger.PrintMessage(string.Format("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter));
            this.Game.Logger.PrintSecretWord(this.Game.WordGuess.HiddenWord);
        }
    }
}
