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

        public WordInitializator WordInit { get; set; }

        public WordSelector WordSelect { get; set; }

        private WordGuesser WordGuess { get; set; }

        public CommandManager execute { get; set; }

        public GameEngine()
        {
            execute = new CommandManager();
            WordInit = new WordInitializator();
            WordSelect = new WordSelector();
        }

        internal void NewGame()
        {
            string word = WordSelect.SelectRandomWord();
            //// Console.WriteLine(word);
            WordInit.BegginingOfTheGameInitialization(word);

            WordGuess = new WordGuesser() { Word = word };
            string commandToExecute = string.Empty;

            while (WordInit.guessedLetters < word.Length && gameIsOn == true)
            {
                commandToExecute = WordGuess.GuessLetter(WordInit, WordSelect);

                if (commandToExecute.Equals(Command.restart.ToString()))
                {
                    execute.Restart();
                }
                else if (commandToExecute.Equals(Command.exit.ToString()))
                {
                    execute.Exit();
                }
            }
        }
    }
}
