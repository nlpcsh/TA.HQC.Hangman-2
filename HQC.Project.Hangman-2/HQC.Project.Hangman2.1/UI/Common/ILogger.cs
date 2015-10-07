// <copyright file="ILogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.UI.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// ???
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Print game title.
        /// </summary>
        void PrintGameTitle();

        /// <summary>
        /// Print good bye message.
        /// </summary>
        void PrintGoodBuyMessage();

        /// <summary>
        /// Print message.
        /// </summary>
        /// <param name="message">Message to print.</param>
        void PrintMessage(string message);

        /// <summary>
        /// Print hidden word.
        /// </summary>
        /// <param name="hiddenWord">Word to hidden.</param>
        void PrintSecretWord(string hiddenWord);

        /// <summary>
        /// Print different hangman depends on player lives.
        /// </summary>
        /// <param name="playerLives">How many lives has player.</param>
        void PrintHangman(int playerLives);

        /// <summary>
        /// Split game field on two parts. 
        /// </summary>
        void PrintVerticalMiddleBorder();

        /// <summary>
        /// Show to user that can write command.
        /// </summary>
        void PrintEnterCommandMessage();

        /// <summary>
        /// Print all used letters.
        /// </summary>
        /// <param name="letters">Used letters</param>
        void PrintUsedLetters(ISet<char> letters);

        /// <summary>
        /// Show to user that can enter name.
        /// </summary>
        void PrintGameInitialization();

        /// <summary>
        /// Print all things like menu or categories or rules.
        /// </summary>
        void Print(IList<string> options);

        /// <summary>
        /// Read all from user.
        /// </summary>
        /// <returns>To game engine string with command.</returns>
        string ReadInput();
    }
}
