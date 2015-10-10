// <copyright file="RevealGuessedLettersCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.GameCommands
{
    using System.Linq;
    using System.Text;
    using HQC.Project.Hangman.Common;

    /// <summary>
    /// This command reveal guessed letters.
    /// </summary>
    public class RevealGuessedLettersCommand : GameCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevealGuessedLettersCommand"/> class.
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public RevealGuessedLettersCommand(HangmanGame game)
            : base(game)
        {
        }

        /// <summary>
        /// Open guessed letter to user.
        /// </summary>
        public override void Execute()
        {
            var supposedChar = this.Game.CurrentCommand[0];
            this.RevealGuessedLetters(supposedChar);
            this.UpdatePlayer(this.Game, supposedChar);
        }

        private void UpdatePlayer(HangmanGame hangmanGame, char supposedChar)
        {
            int numberOfTheAppearancesOfTheSupposedChar = this.Game.Player.Word.Count(x => x.Equals(this.Game.CurrentCommand[0]));
            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                this.Game.Player.Lives--;
                this.Game.Player.WrongLetters.Add(supposedChar);
            }
            else
            {
                this.Game.Player.Score += Globals.ScoreToAdd;
            }
        }

        private void RevealGuessedLetters(char supposedChar)
        {
            var startIndex = 0;
            var index = this.Game.Player.Word.IndexOf(supposedChar, startIndex);

            while (index != -1)
            {
                var word = new StringBuilder(this.Game.Player.HiddenWord);
                word[index] = supposedChar;
                this.Game.Player.HiddenWord = word.ToString();
                startIndex = index + 1;
                index = this.Game.Player.Word.IndexOf(supposedChar, startIndex);
            }
        }
    }
}
