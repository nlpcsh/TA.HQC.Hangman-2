namespace HQC.Project.Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using HQC.Project.Hangman2._1.Common;
    using HQC.Project.Hangman2._1.GameStates;

    public class GameEngine
    {
        private bool gameIsOn = true;

        public GameEngine()
        {
            this.Execute = new CommandManager();
            this.WordSelect = new WordSelector();
            this.Scores = new ScoreBoard();
            this.State = new InitializeGameState();
            this.WordGuess = new WordGuesser();
        }

        public GameState State { get; set; }

        public WordSelector WordSelect { get; set; }

        public WordGuesser WordGuess { get; set; }

        public CommandManager Execute { get; set; }

        public ScoreBoard Scores { get; set; }

        public Player Player { get; set; }

        internal void NewGame()
        {
           // while(true)
           // {
                this.State.Play(this);
           // }

            //string word = this.WordSelect.SelectRandomWord("../../Words/words.txt");
            //Printer.PrintGameTitle();
            //Printer.PrintVerticalMiddleBorder();
            //Printer.PrintEnterCommandMessage();
            //Printer.PrintUsedLetters(new List<char>());
            //Printer.PrintHangman(this.CurrentPlayer.Lives);
            //
            //this.WordGuess = new WordGuesser() { Word = word };
            //this.WordGuess.InitializationOfGame();
            //
            //string commandToExecute = string.Empty;
            //
            //
            //
            //while (this.gameIsOn == true)
            //{
            //    commandToExecute = this.Execute.ReadInput();
            //
            //    if (commandToExecute.Length == 1)
            //    {
            //        char supposedChar = commandToExecute[0];
            //        this.gameIsOn = this.WordGuess.InitializationAfterTheGuess(supposedChar);
            //    }
            //    else if (commandToExecute.Equals(Command.Help.ToString().ToLower()))
            //    {
            //        this.WordGuess.RevealTheNextLetter();
            //    }
            //    else if (commandToExecute.Equals(Command.Top.ToString().ToLower()))
            //    {
            //        this.Scores.PrintTopResults();
            //    }
            //    else if (commandToExecute.Equals(Command.Restart.ToString().ToLower()))
            //    {
            //        // this.Execute.Restart();
            //        this.NewGame();
            //    }
            //    else if (commandToExecute.Equals(Command.Exit.ToString().ToLower()))
            //    {
            //        // this.Execute.Exit();
            //        Printer.PrintGoodBuyMessage();
            //        Environment.Exit(0);
            //    }
            //    else if (commandToExecute.Equals(Command.Options.ToString().ToLower()))
            //    {
            //        Printer.PrintOptionsMessage();
            //    }
            //    else
            //    {
            //        Printer.PrintWrongMessage("Wrong command, please try again!");
            //    }
            //
            //    ConsoleHelper.ClearConsoleInRange(Globals.LeftPositionCommandInput, Globals.LeftPositionCommandInput + commandToExecute.Length,
            //        Globals.TopPositionCommandInput);
            //    ConsoleHelper.ClearConsoleInRange(Console.WindowWidth / 2 + 1, Console.WindowWidth - 1, Globals.TopPositionCommandInput + 2);
            //
            //}
            //
            //
            //this.EndOfTheGame();
            //this.PlayAgain();
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
           //  //Console.WriteLine("You won with {0} mistakes.", this.WordGuess.Mistakes);
           //  Printer.PrintWrongMessage(string.Format("You won with {0} mistakes.", this.WordGuess.Mistakes));
           // 
           //  Printer.PrintSecretWord(this.WordGuess.HiddenWord);
           //  Console.WriteLine("Please enter your name for the top scoreboard:");
           // 
           //  string playerName = Console.ReadLine();
           // 
           //  this.Player.Name = playerName;
           //  this.Player.Mistakes = this.WordGuess.Mistakes;
           // 
           //  this.Scores.PlacePlayerInScoreBoard(this.Player);
           // 
           //  this.WordGuess.Mistakes = 0;
        }
    }
}
