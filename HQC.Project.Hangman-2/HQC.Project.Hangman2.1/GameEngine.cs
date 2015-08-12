namespace HQC.Project.Hangman2._1
{
    using System;

    public class GameEngine
    {
        private bool gameIsOn = true;

        private WordSelector WordSelect { get; set; }

        private WordGuesser WordGuess { get; set; }

        private CommandManager Execute { get; set; }

        private ScoreBoard Scores { get; set; }

        public GameEngine()
        {
            this.Execute = new CommandManager();
            this.WordSelect = new WordSelector();
            this.Scores = new ScoreBoard();
        }

        internal void NewGame()
        {
            Printer.PrintWellcomeMessage();
            Printer.PrintOptionsMessage();

            string word = WordSelect.SelectRandomWord();

            WordGuess = new WordGuesser() { Word = word };
            WordGuess.InitializationOfGame();

            string commandToExecute = string.Empty;

            while (gameIsOn == true)
            {
                commandToExecute = Execute.ReadInput();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    gameIsOn = WordGuess.InitializationAfterTheGuess(supposedChar);
                }
                else if (commandToExecute.Equals(Command.help.ToString()))
                {
                    WordGuess.RevealTheNextLetter();
                }
                else if (commandToExecute.Equals(Command.top.ToString()))
                {
                    this.Scores.PrintTopResults();
                }
                else if (commandToExecute.Equals(Command.restart.ToString()))
                {
                    Execute.Restart();
                }
                else if (commandToExecute.Equals(Command.exit.ToString()))
                {
                    Execute.Exit();
                }
                else if (commandToExecute.Equals(Command.options.ToString()))
                {
                    Printer.PrintOptionsMessage();
                }
            }

            EndOfTheGame(WordGuess);
            PlayAgain();
        }

        private void PlayAgain()
        {
            Console.Write("Want to play again? y/n ");
            char playAgainYesNo = Console.ReadKey().KeyChar;

            Console.WriteLine();

            if (playAgainYesNo == 'y')
            {
                this.gameIsOn = true;
                Execute.Restart();
            }
            else
            {
                Execute.Exit();
            }
        }

        public void EndOfTheGame(WordGuesser WordGuess)
        {
            Console.WriteLine("You won with {0} mistakes.", WordGuess.Mistakes);

            Printer.PrintSecretWord(WordGuess.HiddenWord);
            Console.WriteLine("Please enter your name for the top scoreboard:");

            string playerName = Console.ReadLine();

            Player currentPlayer = new Player(playerName, WordGuess.Mistakes);

            this.Scores.PlacePlayerInScoreBoard(currentPlayer);

            WordGuess.Mistakes = 0;
        }
    }
}
