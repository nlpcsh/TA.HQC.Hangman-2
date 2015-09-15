namespace HQC.Project.Hangman2._1
{
    using System;

    public static class Printer
    {
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
    }
}