namespace HQC.Project.Hangman2._1
{
    using System;

    public class CommandManager
    {
        private string input;

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
        
        public CommandManager()
        {
            this.input = string.Empty;
        }

        public string ReadInput()
        {
            this.Input = Console.ReadLine();
            return this.Input;
        }

        //public void Restart()
        //{
        //    var newGame = new GameEngine();
        //    newGame.NewGame();
        //}

        //public void Exit()
        //{
        //    Printer.PrintGoodBuyMessage();
        //    Environment.Exit(0);
        //}
    }
}
