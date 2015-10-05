namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2;

    public class HelpCommand : GameCommand
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
