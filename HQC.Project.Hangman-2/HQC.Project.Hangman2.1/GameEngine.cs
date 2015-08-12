namespace HQC.Project.Hangman2._1
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
            string word = WordSelect.SelectRandomWord();

            this.WordGuess = new WordGuesser() { Word = word };
            this.WordGuess.InitializationOfGame();

            string commandToExecute = string.Empty;

            while (gameIsOn == true)
            {
                commandToExecute = Execute.ReadInput();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    gameIsOn = this.WordGuess.InitializationAfterTheGuess(supposedChar);
                }
                else if (commandToExecute.Equals(Command.help.ToString()))
                {
                    this.WordGuess.RevealTheNextLetter();
                }
                else if (commandToExecute.Equals(Command.top.ToString()))
                {
                    this.Scores.PrintTopResults();
                }
                else if (commandToExecute.Equals(Command.restart.ToString()))
                {
                    //this.Execute.Restart();
                    this.NewGame();
                }
                else if (commandToExecute.Equals(Command.exit.ToString()))
                {
                    //this.Execute.Exit();
                    Printer.PrintGoodBuyMessage();
                    Environment.Exit(0);

                }
                else if (commandToExecute.Equals(Command.options.ToString()))
                {
                    Printer.PrintOptionsMessage();
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
                //Execute.Restart();
                this.NewGame();
            }
            else
            {
                //Execute.Exit();
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
