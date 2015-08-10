namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordGuesser
    {
        //public static bool IsExited;

        public WordGuesser()
        {
            this.Scores = new ScoreBoard();
        }

        public string Word { get; set; }

        public ScoreBoard Scores { get; set; }

        //// 2 methods from WordInitializator must be moved here!
        public string GuessLetter(WordInitializator wordInit, WordSelector wordSelect)
        {
            Console.WriteLine("Enter your guess: ");
            string supposedCharOrCommand = Console.ReadLine().ToLower();

            //// the input is a character
            if (supposedCharOrCommand.Length == 1)
            {
                char supposedChar = supposedCharOrCommand[0];
                wordInit.InitializationAfterTheGuess(this.Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals(Command.help.ToString()))
            {
                wordInit.RevealTheNextLetter(this.Word);
            }
            //else if (supposedCharOrCommand.Equals("restart"))
            //{
            //    execute.Start(wordSelect, wordInit);
            //}
            //else if (supposedCharOrCommand.Equals("exit"))
            //{
            //    execute.Exit();
            //    return;
            //}
            else if (supposedCharOrCommand.Equals(Command.top.ToString()))
            {
                this.Scores.PrintTopResults();
            }

            return supposedCharOrCommand;
        }
    }
}
