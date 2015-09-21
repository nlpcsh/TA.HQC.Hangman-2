namespace HQC.Project.Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HQC.Project.Hangman2._1.Common;
    using System.Threading;

    public static class Printer
    {
        public static void PrintGameTitle()
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

        public static void PrintWellcomeMessage()
        {
            Console.WriteLine("Welcome to \"Hangman\" game. Please try to guess my secret word.");
            Console.WriteLine();
        }

        public static void PrintOptionsMessage()
        {
            Console.WriteLine("Use \n 'top' to view the top scoreboard,\n 'restart' to start a new game,\n 'help' to cheat,\n 'options' to see again the options and \n 'exit' to quit the game.");
            Console.WriteLine();
        }

        public static void PrintSecretWord(string hiddenWord)
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

        public static void PrintGoodBuyMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good bye!");
        }

        public static void PrintWrongMessage(string message)
        {
            Console.SetCursorPosition(Globals.LeftPositionCommandInput - message.Length / 2, Globals.TopPositionCommandInput + 2);
            // Console.WriteLine("Wrong command, please try again!");
            Console.WriteLine(message);
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
            Thread.Sleep(2000);
        }

        public static void PrintHangman(int playerLives)
        {
            var playerPattern = HangmanPattern.Patterns[playerLives];
            var heigth = Console.WindowHeight / 2 - playerPattern.Length / 9;

            Console.SetCursorPosition(1, heigth);
            for (int i = 0; i < playerPattern.Length; i++)
            {
                Console.WriteLine(playerPattern[i]);
            }
        }

        public static void PrintVerticalMiddleBorder()
        {
            var width = Console.WindowWidth / 2;

            for (int i = 8; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.WriteLine("|");
            }
        }

        public static void PrintEnterCommandMessage()
        {
            var left = Console.WindowWidth - (Console.WindowWidth / 4) - Globals.EnterLetterMessage.Length / 2; ;
            var top = Console.WindowHeight / 2 - (Console.WindowHeight / 4);

            Console.SetCursorPosition(left, top);
            Console.WriteLine(Globals.EnterLetterMessage);
        }

        public static void PrintUsedLetters(IList<char> letters)
        {
            var leftMessage = Console.WindowWidth - (Console.WindowWidth / 4) - Globals.UsedLettersMessage.Length / 2; ;
            var topMessage = Console.WindowHeight / 2 + (Console.WindowHeight / 4);

            Console.SetCursorPosition(leftMessage, topMessage);
            Console.WriteLine(Globals.UsedLettersMessage);

            var lettersAsString = string.Join(", ", letters);
            var leftLetters = Console.WindowWidth - (Console.WindowWidth / 4) - lettersAsString.Length / 2; ;
            var topLetters = topMessage + 2;

            Console.SetCursorPosition(leftLetters, topLetters);
            Console.WriteLine(lettersAsString);
        }
    }
}