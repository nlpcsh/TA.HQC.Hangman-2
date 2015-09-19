namespace HQC.Project.Hangman
{
    using System;

    public class GameEngine
    {
        private bool gameIsOn = true;

        public GameEngine()
        {
            this.Execute = new CommandManager();
            this.WordSelect = new WordSelector();
            this.Scores = new ScoreBoard();
            this.CurrentPlayer = new Player();
        }

        private WordSelector WordSelect { get; set; }

        private WordGuesser WordGuess { get; set; }

        private CommandManager Execute { get; set; }

        private ScoreBoard Scores { get; set; }

        private Player CurrentPlayer { get; set; }

        internal void NewGame()
        {
            string word = this.WordSelect.SelectRandomWord();

            this.WordGuess = new WordGuesser() { Word = word };
            this.WordGuess.InitializationOfGame();

            string commandToExecute = string.Empty;

            while (this.gameIsOn == true)
            {
                commandToExecute = this.Execute.ReadInput();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    this.gameIsOn = this.WordGuess.InitializationAfterTheGuess(supposedChar);
                }
                else if (commandToExecute.Equals(Command.Help.ToString().ToLower()))
                {
                    this.WordGuess.RevealTheNextLetter();
                }
                else if (commandToExecute.Equals(Command.Top.ToString().ToLower()))
                {
                    this.Scores.PrintTopResults();
                }
                else if (commandToExecute.Equals(Command.Restart.ToString().ToLower()))
                {
                    // this.Execute.Restart();
                    this.NewGame();
                }
                else if (commandToExecute.Equals(Command.Exit.ToString().ToLower()))
                {
                    // this.Execute.Exit();
                    Printer.PrintGoodBuyMessage();
                    Environment.Exit(0);
                }
                else if (commandToExecute.Equals(Command.Options.ToString().ToLower()))
                {
                    Printer.PrintOptionsMessage();
                }
                else
                {
                    Printer.PrintWrongMessage();
                }
            }

            this.EndOfTheGame();
            this.PlayAgain();
        }

        private void PlayAgain()
        {
            Console.Write("Want to play again? y/n ");
            char playAgainYesNo = Console.ReadKey().KeyChar;

            Console.WriteLine();

            if (playAgainYesNo == 'y')
            {
                this.gameIsOn = true;

                // Execute.Restart();
                this.NewGame();
            }
            else
            {
                // Execute.Exit();
                Printer.PrintGoodBuyMessage();
                Environment.Exit(0);
            }
        }

        private void EndOfTheGame()
        {
            Console.WriteLine("You won with {0} mistakes.", this.WordGuess.Mistakes);

            Printer.PrintSecretWord(this.WordGuess.HiddenWord);
            Console.WriteLine("Please enter your name for the top scoreboard:");

            string playerName = Console.ReadLine();

            this.CurrentPlayer.Name = playerName;
            this.CurrentPlayer.Mistakes = this.WordGuess.Mistakes;

            this.Scores.PlacePlayerInScoreBoard(this.CurrentPlayer);

            this.WordGuess.Mistakes = 0;
        }
    }
}
