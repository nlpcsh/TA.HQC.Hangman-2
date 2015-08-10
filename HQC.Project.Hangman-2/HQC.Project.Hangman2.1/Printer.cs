namespace HQC.Project.Hangman2._1
{
    using System;

    public static class Printer
    {
        public static void PrintStartHangmanGameMessage(string hiddenWord)
        {
            Console.WriteLine("Welcome to \"Hangman\" game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");
            Console.WriteLine();
            PrintSecretWord(hiddenWord);
        }

        public static void PrintSecretWord(string hiddenWord)
        {
            Console.WriteLine("The secret word is: ");
            Console.WriteLine(hiddenWord);
            Console.WriteLine();
        }
    }
}
