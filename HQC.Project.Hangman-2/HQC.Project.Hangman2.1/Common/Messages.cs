// <copyright file="Messages.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains all game messages
    /// </summary>
    public partial class Messages
    {
        /// <summary>
        /// Contains Good buy message
        /// </summary>
        public const string GoodBuy = "Good bye!";

        /// <summary>
        /// Contains enter choice message
        /// </summary>
        public const string EnterChoiceMessage = "Enter your choice:";

        /// <summary>
        /// Contains Press any key to continue message
        /// </summary>
        public const string PressAnyKeyMessage = "Press any key to continue....";

        /// <summary>
        /// Message for wrong command input
        /// </summary>
        public const string WrongMessage = "Wrong command!";

        /// <summary>
        /// Message for wrong input
        /// </summary>
        public const string WrongInputMessage = "Wrong input, please try again!";

        /// <summary>
        /// Contains header of Categories
        /// </summary>
        public const string Categories = "CATEGORIES";

        /// <summary>
        /// Contains Top 5 players message
        /// </summary>
        public const string BestScores = "Top 5 players";

        /// <summary>
        ///  Contains Win game message
        /// </summary>
        public const string WinGameMessage = "You won! Your score is {0}";

        /// <summary>
        /// Contains secret words message
        /// </summary>
        public const string SecretWord = "The secret word is: ";

        /// <summary>
        /// Contains wrong command message
        /// </summary>
        public const string WrongCommand = "Wrong command, please try again!";

        /// <summary>
        /// Contains enter letters message
        /// </summary>
        public const string EnterLetterMessage = "Please enter a letter:";

        /// <summary>
        /// Contains enter name message
        /// </summary>
        public const string EnterNameMessage = "Please enter your name: ";

        /// <summary>
        /// Contains used letters message
        /// </summary>
        public const string UsedLettersMessage = "Used letter:";

        /// <summary>
        /// Contains reveal letter message
        /// </summary>
        public const string RevealLetterMessage = "OK, I reveal for you the next letter {0}.";

        /// <summary>
        /// Contains play again message
        /// </summary>
        public const string PlayAgainMessage = "Want to play again? y/n: ";

        /// <summary>
        /// Contains message for needed points to use help option
        /// </summary>
        public const string CantUseHelp = "You don't have {0} points!";

        private static readonly List<string> RulesInfoValue = new List<string>()
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

        private static readonly List<string> MenuOptionsValue = new List<string>()
        {
            "MENU:",
            "------",
            "PLAY",
            "RULES",
            "SCORES",
            "EXIT",
            Messages.EnterChoiceMessage
        };

        private static readonly List<string> GameTitleValue = new List<string>()
        {
            "",
            "00  00     000     00    00  0000   00     00     000     00    00",
            "00  00    00 00    0000  00 00      0000 0000    00 00    0000  00",
            "000000   0000000   00 00 00 00 0000 00 000 00   0000000   00 00 00",
            "00  00  00     00  00   000 00   00 00  0  00  00     00  00   000",
            "00  00 00       00 00    00  00000  00     00 00       00 00    00",
            ""
        };

        /// <summary>
        /// Contains rules on the game
        /// </summary>
        public static List<string> RulesInfo
        {
            get
            {
                return RulesInfoValue;
            }
        }

        /// <summary>
        /// Contains all menu options
        /// </summary>
        public static List<string> MenuOptions
        {
            get
            {
                return MenuOptionsValue;
            }
        }

        /// <summary>
        /// Contains game title array
        /// </summary>
        public static List<string> GameTitle
        {
            get
            {
                return GameTitleValue;
            }
        }
    }
}
