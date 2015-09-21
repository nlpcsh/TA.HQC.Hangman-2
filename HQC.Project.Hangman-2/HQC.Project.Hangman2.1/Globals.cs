using System;
namespace HQC.Project.Hangman
{
    /// <summary>
    /// Keeps all constants used in the game
    /// </summary>
    public static class Globals
    {
        public const int ScoreBoardSize = 5;
        public const int LastPositionInScoreBoard = 4;
        public const string FreePositionInScoreBoars = "unknown-0";
        public const string NoPlayer = "No Player";

        public static int TopPositionCommandInput = Console.WindowHeight / 2 - (Console.WindowHeight / 4) + 2;
        public static int LeftPositionCommandInput = Console.WindowWidth - (Console.WindowWidth / 4);

        // Game messages
        public const string Wellcome = "Welcome to \"Hangman\" game. Please try to guess my secret word.";
        public const string Options = "Use \n 'top' to view the top scoreboard,\n 'restart' to start a new game,\n 'help' to cheat,\n 'options' to see again the options and \n 'exit' to quit the game.";
        public const string SecretWord = "The secret word is: ";
        public const string GoodBuy = "Good bye!";
        public const string WrongCommand = "Wrong command, please try again!";
        public const string EnterSecretMessage = "The secret word is:";
        public const string EnterLetterMessage = "Please enter a letter:";
        public const string UsedLettersMessage = "Used letter:";
    }
}
