// <copyright file="Messages.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ???
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// ???
        /// </summary>
        public const string GoodBuy = "Good bye!";

        /// <summary>
        /// ???
        /// </summary>
        public const string EnterChoiceMessage = "Enter your choice:";

        /// <summary>
        /// ???
        /// </summary>
        public const string PressAnyKeyMessage = "Press any key to continue....";

        /// <summary>
        /// ???
        /// </summary>
        public const string Categories = "CATEGORIES";

        /// <summary>
        /// ???
        /// </summary>
        public const string PressToContinue = "/or press any key for random word/";

        /// <summary>
        /// ???
        /// </summary>
        public const string BestScores = "Top 5 players";

        /// <summary>
        /// ???
        /// </summary>
        public const string WinGameMessage = "You won! Your score is {0}";

        /// <summary>
        /// ???
        /// </summary>
        public const string SecretWord = "The secret word is: ";

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
        public const string EnterNameMessage = "Please enter your name: ";

        /// <summary>
        /// ???
        /// </summary>
        public const string UsedLettersMessage = "Used letter:";

        /// <summary>
        /// ???
        /// </summary>
        public const string RevealLetterMessage = "OK, I reveal for you the next letter {0}.";

        /// <summary>
        /// ???
        /// </summary>
        public const string CantUseHelp = "You don't have {0} points!";

        /// <summary>
        /// ???
        /// </summary>
        public static readonly List<string> rulesInfo = new List<string>()
        {
            "Welcome to Hangman game!",
            "Rules are simple: guess secret word and keep your head on your shoulders :)",
            "You can open secret word letter by letter or ",
            "guess whole word with one shot and double closed letters as bonus to your score.",
            "If you are in trouble (and have 50 or more points) you can ask for help ",
            "and we will open one letter for you (of course you will lose 50 points)",
            "Enjoy!",
            Messages.PressAnyKeyMessage
        };

        /// <summary>
        /// ???
        /// </summary>
        public static readonly List<string> menuOptions = new List<string>()
        {
            "MENU:",
            "------",
            "PLAY",
            "RULES",
            "SCORES",
            "EXIT",
            Messages.EnterChoiceMessage
        };

        /// <summary>
        /// ???
        /// </summary>
        public static readonly List<string> gameTitle = new List<string>()
        {
            "00  00     000     00    00  0000   00     00     000     00    00",
            "00  00    00 00    0000  00 00      0000 0000    00 00    0000  00",
            "000000   0000000   00 00 00 00 0000 00 000 00   0000000   00 00 00",
            "00  00  00     00  00   000 00   00 00  0  00  00     00  00   000",
            "00  00 00       00 00    00  00000  00     00 00       00 00    00",
            new string('_', Console.BufferWidth),
            new string('-', Console.BufferWidth)
        };
    }
}
