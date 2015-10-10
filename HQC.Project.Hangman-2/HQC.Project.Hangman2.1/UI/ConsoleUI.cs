// <copyright file="ConsoleLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.UI
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Contracts;
    using HQC.Project.Hangman.Common;

    /// <summary>
    /// Print messages on console.
    /// </summary>
    public class ConsoleUI : IUI
    {
        private readonly int topPositionCommandInput = (Console.WindowHeight / 2) - (Console.WindowHeight / 4) + 4;
        private readonly int leftPositionCommandInput = Console.WindowWidth - (Console.WindowWidth / 4);

        /// <summary>
        /// Initialize Console method
        /// </summary>
        public void Initialize()
        {
            Console.WindowHeight = Messages.GameTitle.Count + HangmanPattern.Patterns[0].Length + 8;
        }

        /// <summary>
        /// ReInitialize Console method
        /// </summary>
        public void ReInitizlize()
        {
            Console.Clear();
            this.Print(Messages.MenuOptions);
        }

        /// <summary>
        /// Prints all messages in the Game
        /// </summary>
        /// <param name="message">Message to be printed in UI</param>
        /// <param name="position">Additional information depending on the UI</param>
        public void Print(string message, string position)
        {
            switch (position)
            {
                case "Title":
                    this.PrintGameTitle();
                    break;
                case "GameInit":
                    this.PrintGameInitialization();
                    break;
                case "Message":
                    this.PrintMessage(message);
                    break;
                case "SecretWord":
                    this.PrintSecretWord(message);
                    break;
                case "GoodBuy":
                    this.PrintGoodBuyMessage();
                    break;
                case "MiddleBorder":
                    this.PrintVerticalMiddleBorder();
                    break;
                case "Lives":
                    this.PrintHangman(int.Parse(message));
                    break;
                case "EnterCommand":
                    this.PrintEnterCommandMessage();
                    break;
                case "Clean":
                    this.PrintClearConsoleInRange(message);
                    break;
                default:
                    break;
            }
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
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), top + 4 + (2 * i));
                    Console.Write(options[i]);
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), top + 4 + (2 * i));
                    Console.WriteLine(options[i]);
                }
            }
        }

        /// <summary>
        /// Print which letters user is used.
        /// </summary>
        /// <param name="letters">All used letters by user.</param>
        public void Print(ISet<char> letters)
        {
            var leftMessage = Console.WindowWidth - (Console.WindowWidth / 4) - (Messages.UsedLettersMessage.Length / 2);
            var topMessage = (Console.WindowHeight / 2) + (Console.WindowHeight / 4);

            Console.SetCursorPosition(leftMessage, topMessage);
            Console.WriteLine(Messages.UsedLettersMessage);

            var lettersAsString = string.Join(", ", letters);
            var leftLetters = Console.WindowWidth - (Console.WindowWidth / 4) - (lettersAsString.Length / 2);
            var topLetters = topMessage + 2;

            Console.SetCursorPosition(leftLetters + 4, topLetters);
            Console.WriteLine(lettersAsString);
        }

        /// <summary>
        /// Read key from Console UI method
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            return Console.ReadLine().Trim().ToLower();
        }

        /// <summary>
        /// Read key from Console UI method
        /// </summary>
        /// <returns></returns>
        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

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

            Console.WriteLine(new string('_', Console.BufferWidth));
            Console.WriteLine(new string('-', Console.BufferWidth));
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
            Console.SetCursorPosition(this.leftPositionCommandInput - (message.Length / 2), this.topPositionCommandInput);
            Console.WriteLine(message);
            Console.SetCursorPosition(this.leftPositionCommandInput, Console.CursorTop);
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

            Console.SetCursorPosition(leftPositionMessage + 2, top);
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
            var heigth = Messages.GameTitle.Count + 3;

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
            var top = Messages.GameTitle.Count + 4;

            Console.SetCursorPosition(left, top);
            Console.WriteLine(Messages.EnterLetterMessage);
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
        /// Clears the Console in a given range
        /// </summary>
        /// <param name="currentCommandLength"></param>
        public void PrintClearConsoleInRange(string currentCommandLength)
        {
            ConsoleHelper.ClearConsoleInRange(this.leftPositionCommandInput, this.leftPositionCommandInput + int.Parse(currentCommandLength), this.topPositionCommandInput);
            ConsoleHelper.ClearConsoleInRange((Console.WindowWidth / 2) + 1, Console.WindowWidth, this.topPositionCommandInput);
        }

        /// <summary>
        /// Read users key input.
        /// </summary>
        /// <returns>What user is write to lower case.</returns>
        public string ReadKeyInput()
        {
            Console.SetCursorPosition(this.leftPositionCommandInput, this.topPositionCommandInput + 2);
            var input = Console.ReadLine();
            return input.ToLower();
        }
    }
}