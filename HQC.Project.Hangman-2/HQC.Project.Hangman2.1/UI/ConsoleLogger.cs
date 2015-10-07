// <copyright file="ConsoleLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI.Common;

    /// <summary>
    /// Print messages on console.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private int commandMessageTopPosition = Globals.TopPositionCommandInput + 2;

        /// <summary>
        /// Print game title on console.
        /// </summary>
        public void PrintGameTitle()
        {
            Console.Clear();
            for (int i = 0; i < Messages.GameTitle.Count; i++)
            {
                Console.WriteLine(Messages.GameTitle[i]);
            }
        }

        /// <summary>
        /// Print good bye message on console.
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
        /// Print message on console.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public void PrintMessage(string message)
        {
            Console.SetCursorPosition(Globals.LeftPositionCommandInput - (message.Length / 2), this.commandMessageTopPosition);
            Console.WriteLine(message);
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Print hidden word.
        /// </summary>
        /// <param name="hiddenWord">Word to print hidden.</param>
        public void PrintSecretWord(string hiddenWord)
        {
            var leftPositionMessage = Console.WindowWidth - (Console.WindowWidth / 4) - (Messages.SecretWord.Length / 2);
            var top = Console.WindowHeight / 2;

            Console.SetCursorPosition(leftPositionMessage, top);
            Console.WriteLine(Messages.SecretWord);

            var leftPositionWord = Console.WindowWidth - (Console.WindowWidth / 4) - (hiddenWord.Length / 2);
            Console.SetCursorPosition(leftPositionWord, top + 2);
            Console.WriteLine(string.Join(" ", hiddenWord.ToCharArray()));
            Console.WriteLine();
        }

        /// <summary>
        /// Print hangman. Different hangman depends on playerLives.
        /// </summary>
        /// <param name="playerLives">How many lives player have.</param>
        public void PrintHangman(int playerLives)
        {
            var playerPattern = HangmanPattern.Patterns[playerLives];
            var heigth = Messages.GameTitle.Count + 1;

            Console.SetCursorPosition(1, heigth);
            for (int i = 0; i < playerPattern.Length; i++)
            {
                Console.WriteLine(playerPattern[i]);
            }
        }

        /// <summary>
        /// Split console on two parts.
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
        /// Show on user where can write on console.
        /// </summary>
        public void PrintEnterCommandMessage()
        {
            var left = Console.WindowWidth - (Console.WindowWidth / 4) - (Messages.EnterLetterMessage.Length / 2);
            var top = Messages.GameTitle.Count;

            Console.SetCursorPosition(left, top);
            Console.WriteLine(Messages.EnterLetterMessage);
        }

        /// <summary>
        /// Print which letters user is used.
        /// </summary>
        /// <param name="letters">All used letters by user.</param>
        public void PrintUsedLetters(ISet<char> letters)
        {
            var leftMessage = Console.WindowWidth - (Console.WindowWidth / 4) - (Messages.UsedLettersMessage.Length / 2);
            var topMessage = (Console.WindowHeight / 2) + (Console.WindowHeight / 4);

            Console.SetCursorPosition(leftMessage, topMessage);
            Console.WriteLine(Messages.UsedLettersMessage);

            var lettersAsString = string.Join(", ", letters);
            var leftLetters = Console.WindowWidth - (Console.WindowWidth / 4) - (lettersAsString.Length / 2);
            var topLetters = topMessage + 2;

            Console.SetCursorPosition(leftLetters, topLetters);
            Console.WriteLine(lettersAsString);
        }

        /// <summary>
        /// Print message for player name initialization.
        /// </summary>
        public void PrintGameInitialization()
        {
            string text = Messages.EnterNameMessage;
            var left = (Console.WindowWidth / 2) - (text.Length / 2);
            var top = Console.WindowHeight / 2;

            Console.SetCursorPosition(left, top);
            Console.Write(text);
        }

        /// <summary>
        /// Print on console menu, rules, categories and scores.
        /// </summary>
        /// <param name="options">Option to print</param>
        public void Print(IList<string> options)
        {
            this.PrintGameTitle();
            var top = Messages.GameTitle.Count;

            for (int i = 0; i < options.Count; i++)
            {
                if (i == options.Count - 1)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), top + (2 * i));
                    Console.Write(options[i]);
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), top + (2 * i));
                    Console.WriteLine(options[i]);
                }
            }
        }

        /// <summary>
        /// Read user input.
        /// </summary>
        /// <returns>What user is write to lower case.</returns>
        public string ReadInput()
        {
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
            var input = Console.ReadLine();
            return input.ToLower();
        }
    }
}