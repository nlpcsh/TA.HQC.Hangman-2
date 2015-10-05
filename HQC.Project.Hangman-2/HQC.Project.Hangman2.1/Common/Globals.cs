namespace HQC.Project.Hangman.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using HQC.Project.Hangman2.Commands;

    /// <summary>
    /// Keeps all constants used in the game
    /// </summary>
    public static class Globals
    {
        public const int ScoreBoardSize = 5;
        public const int LastPositionInScoreBoard = 4;
        public const string FreePositionInScoreBoars = "unknown-0";
        public const string NoPlayer = "No Player";
        public const string CategoriesPath = @"../../Words";
        public const string FileExtension = ".txt";
        public const string BestScoresPath = @"..\..\bestScores.txt";

        // Game messages
        public const string Wellcome = "Welcome to \"Hangman\" game. Please try to guess my secret word.";
        public const string Options = "Use \n 'top' to view the top scoreboard,\n 'restart' to start a new game,\n 'help' to cheat,\n 'options' to see again the options and \n 'exit' to quit the game.";
        public const string SecretWord = "The secret word is: ";
        public const string GoodBuy = "Good bye!";
        public const string WrongCommand = "Wrong command, please try again!";
        public const string EnterSecretMessage = "The secret word is:";
        public const string EnterLetterMessage = "Please enter a letter:";
        public const string UsedLettersMessage = "Used letter:";
        private static readonly IDictionary<string, Type> MenuCommandTypesValue = new Dictionary<string, Type>()
        {
             { "exit", typeof(ExitCommand) },
             { "scores", typeof(TopCommand) },
             { "rules", typeof(ShowGameRulesCommand) },
             { "play", typeof(PlayCommand) }
        };

        private static readonly IDictionary<string, Type> CommandTypesValue = new Dictionary<string, Type>()
        {
             { "help", typeof(HelpCommand) },
             { "restart", typeof(RestartGameCommand) },
        };

        private static int leftPositionCommandInput = Console.WindowWidth - (Console.WindowWidth / 4);

        private static int topPositionCommandInput = (Console.WindowHeight / 2) - (Console.WindowHeight / 4) + 2;

        public static IDictionary<string, Type> CommandTypes
        {
            get
            {
                return CommandTypesValue;
            }
        }

        public static IDictionary<string, Type> MenuCommandTypes
        {
            get
            {
                return MenuCommandTypesValue;
            }
        }

        public static int TopPositionCommandInput
        {
            get
            {
                return topPositionCommandInput;
            }

            set
            {
                topPositionCommandInput = value;
            }
        }

        public static int LeftPositionCommandInput
        {
            get
            {
                return leftPositionCommandInput;
            }

            set
            {
                leftPositionCommandInput = value;
            }
        }
    }
}
