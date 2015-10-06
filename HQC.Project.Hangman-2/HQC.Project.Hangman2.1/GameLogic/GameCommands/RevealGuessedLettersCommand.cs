//namespace HQC.Project.Hangman2._1.GameLogic.GameCommands
//{
//    using HQC.Project.Hangman;
//    using HQC.Project.Hangman2.Commands.Common;

//    public class RevealGuessedLettersCommand : GameCommand
//    {
//        public RevealGuessedLettersCommand(HangmanGame game)
//            : base(game)
//        {
//        }

//        public override void Execute()
//        {
//            var startIndex = 0;
//            var index = this.Game.WordGuess.Word.IndexOf(supposedChar, startIndex);

//            while (index != -1)
//            {
//                this.Game.WordGuess.HiddenWord[index] = supposedChar;
//                startIndex = index + 1;
//                index = this.Game.IndexOf(supposedChar, startIndex);
//            }
//        }
//    }
//}
