// <copyright file="Globals.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using GameLogic.GameCommands;

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
        /// Score that player add when guess a letter
        /// </summary>
        public const int ScoreToAdd = 10;

        /// <summary>
        /// Last position in score board
        /// </summary>
        public const int LastPositionInScoreBoard = 4;

        /// <summary>
        /// Default value for fill position in score board
        /// </summary>
        public const string FreePositionInScoreBoars = "unknown-0";

        /// <summary>
        /// Default value for missing player
        /// </summary>
        public const string NoPlayer = "No Player";

        /// <summary>
        /// Path to directory with all categories with words
        /// </summary>
        public const string CategoriesPath = @"../../Words";

        /// <summary>
        /// All categories file extension
        /// </summary>
        public const string FileExtension = ".txt";

        /// <summary>
        /// Where save or load Top players
        /// </summary>
        public const string BestScoresPath = @"..\..\bestScores.txt";

        /// <summary>
        /// Points needed to player to use Help option
        /// </summary>
        public const int HelpNeededPoints = 50;

        // Game messages
        private static readonly IDictionary<string, Type> MenuCommandTypesValueValue = new Dictionary<string, Type>()
        {
             { "exit", typeof(ExitCommand) },
             { "scores", typeof(TopCommand) },
             { "rules", typeof(ShowGameRulesCommand) },
             { "play", typeof(PlayCommand) }
        };

        private static readonly IDictionary<string, Type> CommandTypesValueValue = new Dictionary<string, Type>()
        {
             { "help", typeof(HelpCommand) },
             { "restart", typeof(RestartGameCommand) },
             { "revealGuessedLetters", typeof(RevealGuessedLettersCommand) }
        };

        /// <summary>
        /// Contains all in menu commands
        /// </summary>
        public static IDictionary<string, Type> MenuCommandTypesValue
        {
            get
            {
                return MenuCommandTypesValueValue;
            }
        }

        /// <summary>
        /// Contains all in game commands
        /// </summary>
        public static IDictionary<string, Type> CommandTypesValue
        {
            get
            {
                return CommandTypesValueValue;
            }
        }
    }
}
