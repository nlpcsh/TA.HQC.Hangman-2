namespace HQC.Project.Hangman2._1
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;

    public class GameEngine
    {
        public static bool gameIsOn = true;

        //public WordInitializator WordInit { get; set; }

        public WordSelector WordSelect { get; set; }

        private WordGuesser WordGuess { get; set; }

        public CommandManager execute { get; set; }

        public GameEngine()
        {
            execute = new CommandManager();
            //WordInit = new WordInitializator();
            WordSelect = new WordSelector();
        }

        internal void NewGame()
        {
            Printer.PrintWellcomeMessage();
            Printer.PrintOptionsMessage();

            string word = WordSelect.SelectRandomWord();
            //// Console.WriteLine(word);
            WordGuess = new WordGuesser() { Word = word };
            WordGuess.InitializationOfGame(word);

            string commandToExecute = string.Empty;

            while (WordGuess.guessedLetters < word.Length && gameIsOn == true)
            {
                commandToExecute = WordGuess.GuessLetter();

                if (commandToExecute.Equals(Command.restart.ToString()))
                {
                    execute.Restart();
                }
                else if (commandToExecute.Equals(Command.exit.ToString()))
                {
                    execute.Exit();
                }
                else if (commandToExecute.Equals(Command.options.ToString()))
                {
                    Printer.PrintOptionsMessage();
                }
            }

            PlayAgain();
        }

        private void PlayAgain()
        {
            System.Console.WriteLine("Want to play again? y/n");
            char playAgainYesNo = System.Console.ReadKey().KeyChar;

            if (playAgainYesNo == 'y')
            {
                GameEngine.gameIsOn = true;
                execute.Restart();
            }
            else
            {
                execute.Exit();
            }
        }
    }
}
