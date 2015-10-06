﻿// <copyright file="Globals.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman.GameLogic.GameCommands;
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
        /// Score that player add when guess a letter
        /// </summary>
        public const int ScoreToAdd = 10;

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

        /// <summary>
        /// Contains all in menu commands
        /// </summary>
        public static readonly IDictionary<string, Type> MenuCommandTypesValue = new Dictionary<string, Type>()
        {
             { "exit", typeof(ExitCommand) },
             { "scores", typeof(TopCommand) },
             { "rules", typeof(ShowGameRulesCommand) },
             { "play", typeof(PlayCommand) }
        };

        /// <summary>
        /// Contains all in game commands
        /// </summary>
        public static readonly IDictionary<string, Type> CommandTypesValue = new Dictionary<string, Type>()
        {
             { "help", typeof(HelpCommand) },
             { "restart", typeof(RestartGameCommand) },
             { "revealGuessedLetters", typeof(RevealGuessedLettersCommand) }
        };

        /// <summary>
        /// Holds column position used from ILogger to clear console when menu have to show off
        /// </summary>
        public static int leftPositionCommandInput = Console.WindowWidth - (Console.WindowWidth / 4);

        /// <summary>
        ///  Holds row position used from ILogger to clear console when menu have to show off
        /// </summary>
        public static int topPositionCommandInput = (Console.WindowHeight / 2) - (Console.WindowHeight / 4) + 2;
    }
}
