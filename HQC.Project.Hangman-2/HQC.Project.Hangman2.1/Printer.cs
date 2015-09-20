namespace HQC.Project.Hangman
{
    using System;
    using System.Text;

    using HQC.Project.Hangman2._1.Common;

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
            Console.WriteLine("The secret word is: ");
            Console.WriteLine(hiddenWord);
            Console.WriteLine();
        }

        public static void PrintGoodBuyMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good bye!");
        }

        public static void PrintWrongMessage()
        {
            Console.WriteLine("Wrong command, please try again!");
            Console.WriteLine();
        }

        public static void PrintHangman(int playerLives)
        {
            var playerPattern = ConsoleHelper.Patterns[playerLives];

            for (int i = 0; i < playerPattern.Length; i++)
            {
                Console.WriteLine(playerPattern[i]);
            }
        }
    }
}