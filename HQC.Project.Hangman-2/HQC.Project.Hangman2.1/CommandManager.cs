﻿namespace HQC.Project.Hangman
{
    using System;

    public class CommandManager
    {
        private string input;

        public CommandManager()
        {
            this.input = string.Empty;
        }

        public string Input
        {
            get
            {
                return this.input;
            }

            set
            {
                this.input = value;
            }
        }

        public string ReadInput()
        {
            this.Input = Console.ReadLine();
            return this.Input.ToLower();
        }

        // public void Restart()
        // {
        //    var newGame = new GameEngine();
        //    newGame.NewGame();
        // }

        // public void Exit()
        // {
        //    Printer.PrintGoodBuyMessage();
        //    Environment.Exit(0);
        // }
    }
}