// <copyright file="Globals.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman2.Commands;

    /// <summary>
    /// Keeps all constants used in the game
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// How many user is in top scores
        /// </summary>
        public const int ScoreBoardSize = 5;

        /// <summary>
        /// ???
        /// </summary>
        public const int LastPositionInScoreBoard = 4;

        /// <summary>
        /// ???
        /// </summary>
        public const string FreePositionInScoreBoars = "unknown-0";

        /// <summary>
        /// ???
        /// </summary>
        public const string NoPlayer = "No Player";

        /// <summary>
        /// ???
        /// </summary>
        public const string CategoriesPath = @"../../Words";

        /// <summary>
        /// ???
        /// </summary>
        public const string FileExtension = ".txt";

        /// <summary>
        /// ???
        /// </summary>
        public const string BestScoresPath = @"..\..\bestScores.txt";

        // Game messages

        /// <summary>
        /// ???
        /// </summary>
        public const string Wellcome = "Welcome to \"Hangman\" game. Please try to guess my secret word.";

        /// <summary>
        /// ???
        /// </summary>
        public const string Options = "Use \n 'top' to view the top scoreboard,\n 'restart' to start a new game,\n 'help' to cheat,\n 'options' to see again the options and \n 'exit' to quit the game.";

        /// <summary>
        /// ???
        /// </summary>
        public const string SecretWord = "The secret word is: ";

        /// <summary>
        /// ???
        /// </summary>
        public const string GoodBuy = "Good bye!";

        /// <summary>
        /// ???
        /// </summary>
        public const string WrongCommand = "Wrong command, please try again!";

        /// <summary>
        /// ???
        /// </summary>
        public const string EnterSecretMessage = "The secret word is:";

        /// <summary>
        /// ???
        /// </summary>
        public const string EnterLetterMessage = "Please enter a letter:";

        /// <summary>
        /// ???
        /// </summary>
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

        /// <summary>
        /// ???
        /// </summary>
        public static IDictionary<string, Type> CommandTypes
        {
            get
            {
                return CommandTypesValue;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public static IDictionary<string, Type> MenuCommandTypes
        {
            get
            {
                return MenuCommandTypesValue;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
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

        /// <summary>
        /// ???
        /// </summary>
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
