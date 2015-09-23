namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;

    public class HelpCommand : Command
    {
        GameEngine game;

        public HelpCommand(GameEngine currentGame)
        {
            this.game = currentGame;
        }

        public override void Execute()
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < game.WordGuess.Word.Length; i++)
            {
                if (game.WordGuess.AllGuessedLetters[i].Equals('$'))
                {
                    firstUnrevealedLetter = game.WordGuess.Word[i];
                    break;
                }
            }


            game.WordGuess.InitializationAfterTheGuess(firstUnrevealedLetter);
            Printer.PrintWrongMessage(string.Format("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter));
            Printer.PrintSecretWord(game.WordGuess.HiddenWord);
           
        }
    }
}
