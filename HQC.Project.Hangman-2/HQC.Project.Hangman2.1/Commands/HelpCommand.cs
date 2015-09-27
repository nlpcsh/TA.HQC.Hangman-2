﻿namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;

    public class HelpCommand : Command
    {
        public HelpCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < this.Game.WordGuess.Word.Length; i++)
            {
                if (this.Game.WordGuess.AllGuessedLetters[i].Equals('$'))
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
