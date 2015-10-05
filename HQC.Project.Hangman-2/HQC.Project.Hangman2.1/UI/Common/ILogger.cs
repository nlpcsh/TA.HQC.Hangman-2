// <copyright file="ILogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.UI
{
    using System.Collections.Generic;
    using Hangman2.Players.Common;

    /// <summary>
    /// ???
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// ???
        /// </summary>
        void PrintGameTitle();

        /// <summary>
        /// ???
        /// </summary>
        void PrintGoodBuyMessage();

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="message">???</param>
        void PrintMessage(string message);

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="hiddenWord">???</param>
        void PrintSecretWord(string hiddenWord);

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="playerLives">???</param>
        void PrintHangman(int playerLives);

        /// <summary>
        /// ???
        /// </summary>
        void PrintVerticalMiddleBorder();

        /// <summary>
        /// ???
        /// </summary>
        void PrintEnterCommandMessage();

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="letters">???</param>
        void PrintUsedLetters(ISet<char> letters);

        /// <summary>
        /// ???
        /// </summary>
        void PrintGameInitialization();

        /// <summary>
        /// ???
        /// </summary>
        void Print(List<string> options);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ReadInput();
    }
}
