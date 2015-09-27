namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.Interfaces;
    using HQC.Project.Hangman2._1.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string line)
        {
            Console.WriteLine(line);
        }

        public void PrintGameTitle()
        {
            var title = new StringBuilder();

            title.AppendLine("00  00     000     00    00  0000   00     00     000     00    00");
            title.AppendLine("00  00    00 00    0000  00 00      0000 0000    00 00    0000  00");
            title.AppendLine("000000   0000000   00 00 00 00 0000 00 000 00   0000000   00 00 00");
            title.AppendLine("00  00  00     00  00   000 00   00 00  0  00  00     00  00   000");
            title.AppendLine("00  00 00       00 00    00  00000  00     00 00       00 00    00");

            Console.WriteLine(title.ToString().Trim());
            Console.WriteLine(new string('_', Console.BufferWidth));
            Console.WriteLine(new string('-', Console.BufferWidth));
        }

        public void PrintWellcomeMessage()
        {
            Console.WriteLine("Welcome to \"Hangman\" game. Please try to guess my secret word.");
            Console.WriteLine();
        }

        public void PrintOptionsMessage()
        {
            Console.WriteLine("Use \n 'top' to view the top scoreboard,\n 'restart' to start a new game,\n 'help' to cheat,\n 'options' to see again the options and \n 'exit' to quit the game.");
            Console.WriteLine();
        }

        public void PrintSecretWord(string hiddenWord)
        {
            var leftPositionMessage = Console.WindowWidth - (Console.WindowWidth / 4) - Globals.EnterSecretMessage.Length / 2;
            var top = Console.WindowHeight / 2;

            Console.SetCursorPosition(leftPositionMessage, top);
            Console.WriteLine(Globals.EnterSecretMessage);

            var leftPositionWord = Console.WindowWidth - (Console.WindowWidth / 4) - hiddenWord.Length / 2;
            Console.SetCursorPosition(leftPositionWord, top + 2);
            Console.WriteLine(hiddenWord);
            Console.WriteLine();
        }

        public void PrintGoodBuyMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good bye!");
        }

        public void PrintMessage(string message)
        {
            Console.SetCursorPosition(Globals.LeftPositionCommandInput - (message.Length / 2), Globals.TopPositionCommandInput + 2);
            Console.WriteLine(message);
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
            Thread.Sleep(1000);
        }

        public void PrintHangman(int playerLives)
        {
            var playerPattern = HangmanPattern.Patterns[playerLives];
            var heigth = Console.WindowHeight / 2 - playerPattern.Length / 9;

            Console.SetCursorPosition(1, heigth);
            for (int i = 0; i < playerPattern.Length; i++)
            {
                Console.WriteLine(playerPattern[i]);
            }
        }

        public void PrintVerticalMiddleBorder()
        {
            var width = Console.WindowWidth / 2;

            for (int i = 8; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.WriteLine("|");
            }
        }

        public void PrintEnterCommandMessage()
        {
            var left = Console.WindowWidth - Console.WindowWidth / 4 - Globals.EnterLetterMessage.Length / 2;
            var top = Console.WindowHeight / 2 - (Console.WindowHeight / 4);

            Console.SetCursorPosition(left, top);
            Console.WriteLine(Globals.EnterLetterMessage);
        }

        public void PrintUsedLetters(ISet<char> letters)
        {
            var leftMessage = Console.WindowWidth - (Console.WindowWidth / 4) - Globals.UsedLettersMessage.Length / 2;
            var topMessage = Console.WindowHeight / 2 + (Console.WindowHeight / 4);

            Console.SetCursorPosition(leftMessage, topMessage);
            Console.WriteLine(Globals.UsedLettersMessage);

            var lettersAsString = string.Join(", ", letters);
            var leftLetters = Console.WindowWidth - (Console.WindowWidth / 4) - lettersAsString.Length / 2;
            var topLetters = topMessage + 2;

            Console.SetCursorPosition(leftLetters, topLetters);
            Console.WriteLine(lettersAsString);
        }

        public void PrintGameInitialization()
        {
            string text = "Please enter your name: ";
            var left = Console.WindowWidth / 2 - text.Length / 2;
            var top = Console.WindowHeight / 2;

            Console.SetCursorPosition(left, top);
            Console.Write(text);
        }

        public void PrintMenu()
        {
            Console.Clear();
            this.PrintGameTitle();
            var top = Console.WindowHeight / 2 - 6;
            var left = (Console.WindowWidth / 2) - "MENU".Length / 2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("MENU:");

            left = (Console.WindowWidth / 2) - ("MENU".Length + 2) / 2;
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine("------");

            left = (Console.WindowWidth / 2) - ("PLAY".Length) / 2;
            Console.SetCursorPosition(left, top + 3);
            Console.WriteLine("PLAY");

            left = (Console.WindowWidth / 2) - ("HELP".Length) / 2;
            Console.SetCursorPosition(left, top + 5);
            Console.WriteLine("HELP");

            left = (Console.WindowWidth / 2) - ("SCORES".Length) / 2;
            Console.SetCursorPosition(left, top + 7);
            Console.WriteLine("SCORES");

            left = (Console.WindowWidth / 2) - ("EXIT".Length) / 2;
            Console.SetCursorPosition(left, top + 9);
            Console.WriteLine("EXIT");
        }
    }
}