namespace HQC.Project.Hangman
{
    using System;
    using HQC.Project.Hangman.Common;

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
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
            this.Input = Console.ReadLine();
            return this.Input.ToLower();
        }
    }
}