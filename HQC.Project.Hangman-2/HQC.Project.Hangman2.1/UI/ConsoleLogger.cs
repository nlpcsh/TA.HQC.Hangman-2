// <copyright file="ConsoleLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using Hangman2.Players.Common;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private int commandMessageTopPosition = Globals.topPositionCommandInput + 2;

        /// <summary>
        /// ???
        /// </summary>
        public void PrintGameTitle()
        {
            Console.Clear();
            for (int i = 0; i < Globals.gameTitle.Count; i++)
            {
                Console.WriteLine(Globals.gameTitle[i]);
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public void PrintGoodBuyMessage()
        {
            Console.Clear();
            this.PrintGameTitle();
            var left = (Console.WindowWidth / 2) - (Messages.GoodBuy.Length / 2);
            var top = Console.WindowHeight / 2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(Messages.GoodBuy);
            Environment.Exit(0);
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="message">???</param>
        public void PrintMessage(string message)
        {
            Console.SetCursorPosition(Globals.leftPositionCommandInput - (message.Length / 2), this.commandMessageTopPosition);
            Console.WriteLine(message);
            Console.SetCursorPosition(Globals.leftPositionCommandInput, Globals.topPositionCommandInput);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="hiddenWord">???</param>
        public void PrintSecretWord(string hiddenWord)
        {
            var leftPositionMessage = Console.WindowWidth - (Console.WindowWidth / 4) - (Globals.EnterSecretMessage.Length / 2);
            var top = Console.WindowHeight / 2;

            Console.SetCursorPosition(leftPositionMessage, top);
            Console.WriteLine(Globals.EnterSecretMessage);

            var leftPositionWord = Console.WindowWidth - (Console.WindowWidth / 4) - (hiddenWord.Length / 2);
            Console.SetCursorPosition(leftPositionWord, top + 2);
            Console.WriteLine(string.Join(" ", hiddenWord.ToCharArray()));
            Console.WriteLine();
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="playerLives">???</param>
        public void PrintHangman(int playerLives)
        {
            var playerPattern = HangmanPattern.Patterns[playerLives];
            var heigth = Globals.gameTitle.Count;

            Console.SetCursorPosition(1, heigth);
            for (int i = 0; i < playerPattern.Length; i++)
            {
                Console.WriteLine(playerPattern[i]);
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public void PrintVerticalMiddleBorder()
        {
            var width = Console.WindowWidth / 2;

            for (int i = 8; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.WriteLine("|");
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public void PrintEnterCommandMessage()
        {
            var left = Console.WindowWidth - (Console.WindowWidth / 4) - (Globals.EnterLetterMessage.Length / 2);
            var top = (Console.WindowHeight / 2) - (Console.WindowHeight / 4);

            Console.SetCursorPosition(left, top);
            Console.WriteLine(Globals.EnterLetterMessage);
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="letters">???</param>
        public void PrintUsedLetters(ISet<char> letters)
        {
            var leftMessage = Console.WindowWidth - (Console.WindowWidth / 4) - (Globals.UsedLettersMessage.Length / 2);
            var topMessage = (Console.WindowHeight / 2) + (Console.WindowHeight / 4);

            Console.SetCursorPosition(leftMessage, topMessage);
            Console.WriteLine(Globals.UsedLettersMessage);

            var lettersAsString = string.Join(", ", letters);
            var leftLetters = Console.WindowWidth - (Console.WindowWidth / 4) - (lettersAsString.Length / 2);
            var topLetters = topMessage + 2;

            Console.SetCursorPosition(leftLetters, topLetters);
            Console.WriteLine(lettersAsString);
        }

        /// <summary>
        /// ???
        /// </summary>
        public void PrintGameInitialization()
        {
            string text = "Please enter your name: ";
            var left = (Console.WindowWidth / 2) - (text.Length / 2);
            var top = Console.WindowHeight / 2;

            Console.SetCursorPosition(left, top);
            Console.Write(text);
        }

        /// <summary>
        /// ???
        /// </summary>
        public void Print(List<string> options)
        {
            this.PrintGameTitle();
            var top = Globals.gameTitle.Count;

            for (int i = 0; i < options.Count; i++)
            {
                if (i == options.Count - 1)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), top + 2 * i);
                    Console.Write(options[i]);
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), top + 2 * i);
                    Console.WriteLine(options[i]);
                }
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <returns>???</returns>
        public string ReadInput()
        {
            Console.SetCursorPosition(Globals.leftPositionCommandInput, Globals.topPositionCommandInput);
            var input = Console.ReadLine();
            return input.ToLower();
        }
    }
}