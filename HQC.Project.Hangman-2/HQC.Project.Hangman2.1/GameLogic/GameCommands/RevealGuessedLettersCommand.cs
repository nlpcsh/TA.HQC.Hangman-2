namespace HQC.Project.Hangman2._1.GameLogic.GameCommands
{
    using System.Linq;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman.Common;
    using System.Text;

    public class RevealGuessedLettersCommand : GameCommand
    {
        public RevealGuessedLettersCommand(HangmanGame game)
            : base(game)
        {
        }

        public override void Execute()
        {
            var supposedChar = this.Game.CurrentCommand[0];
            int numberOfTheAppearancesOfTheSupposedChar = this.Game.WordGuess.Word.Count(x => x.Equals(this.Game.CurrentCommand[0]));

            this.RevealGuessedLetters(supposedChar);

            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                this.Game.WordGuess.Lives--;
                this.Game.WordGuess.WrongLetters.Add(supposedChar);
            }
            else
            {
                this.Game.WordGuess.Score += Globals.ScoreToAdd;
            }
        }

        private void RevealGuessedLetters(char supposedChar)
        {
            var startIndex = 0;
            var index = this.Game.WordGuess.Word.IndexOf(supposedChar, startIndex);

            while (index != -1)
            {
                var word = new StringBuilder(this.Game.WordGuess.HiddenWord);
                word[index] = supposedChar;
                this.Game.WordGuess.HiddenWord = word.ToString();
                startIndex = index + 1;
                index = this.Game.WordGuess.Word.IndexOf(supposedChar, startIndex);
            }
        }
    }
}
