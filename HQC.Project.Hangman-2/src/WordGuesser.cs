namespace HQC.Project.Hangman2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordGuesser
    {
        public static bool IsExited;

        public string Word { get; set; }

        //// 2 methods from WordInitializator must be moved here!
        public void GuessLetter()
        {
            Console.WriteLine("Enter your guess: ");
            string supposedCharOrCommand = Console.ReadLine();
            
            //// the input is a character
            if (supposedCharOrCommand.Length == 1) 
            {
                char supposedChar = supposedCharOrCommand[0];
                WordInitializator.InitializationAfterTheGuess(this.Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals("help"))
            {
                CommandExecuter.RevealTheNextLetter(this.Word);
            }
            else if (supposedCharOrCommand.Equals("restart"))
            {
                CommandExecuter.Start();
            }
            else if (supposedCharOrCommand.Equals("exit"))
            {
                CommandExecuter.Exit();
                return;
            }
            else if (supposedCharOrCommand.Equals("top"))
            {
                CommandExecuter.TopResults();
            }
        }
    }
}
