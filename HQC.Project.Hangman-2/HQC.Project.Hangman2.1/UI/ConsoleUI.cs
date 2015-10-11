// <copyright file="ConsoleLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.UI
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Common;
    using Contracts;

    /// <summary>
    /// Print messages on the console UI.
    /// </summary>
    public class ConsoleUI : IUI
    {
        private readonly int initialConsoleHeight = Messages.GameTitle.Count + HangmanPattern.Patterns[0].Length + 8;
        private readonly int topOptionsPrint = Messages.GameTitle.Count + 4;
        private readonly int topGuessedLetters = (Console.WindowHeight / 2) + (Console.WindowHeight / 4) + 10;
        private readonly int topSecretWord = (Console.WindowHeight / 2) + 8;
        private readonly int topPositionCommandInput = (Console.WindowHeight / 2) - (Console.WindowHeight / 4) + 6;
        private readonly int topPositionEnterCommandMsg = (Console.WindowHeight / 2) - (Console.WindowHeight / 4) + 8;
        private readonly int topHangman = Messages.GameTitle.Count + 3;
        private readonly int topVerticalLine = Messages.GameTitle.Count + 1;
        private readonly int leftSideCenterPoint = Console.WindowWidth - (Console.WindowWidth / 4);

        private int leftMessageGuessedLetters;
        private int leftGuessegLetters;
        private int leftPositionSecretWord;
        private int leftPositionCommandInput;

        /// <summary>
        /// ConsoleUI's constrictor set some properties
        /// </summary>
        public ConsoleUI()
        {
            this.LeftMessageGuessedLetters = Console.WindowWidth - (Console.WindowWidth / 4) - (Messages.UsedLettersMessage.Length / 2);
        }

        /// <summary>
        /// Property for left start position of the secret word
        /// </summary>
        public int LeftPositionSecretWord
        {
            get
            {
                return this.leftPositionSecretWord;
            }

            private set
            {
                if (value <= Console.WindowWidth / 2)
                {
                    throw new ArgumentException("Secret word letters are more than necessary symbols!");
                }

                this.leftPositionSecretWord = value;
            }
        }

        /// <summary>
        /// Property for left start position of the guessed letters
        /// </summary>
        public int LeftGuessedLetters
        {
            get
            {
                return this.leftGuessegLetters;
            }

            private set
            {
                if (value <= Console.WindowWidth / 2)
                {
                    throw new ArgumentException("Guessed letters are more than necessary symbols!");
                }

                this.leftGuessegLetters = value;
            }
        }

        /// <summary>
        /// Property for left start position of the message for guessed letters
        /// </summary>
        public int LeftMessageGuessedLetters
        {
            get
            {
                return this.leftMessageGuessedLetters;
            }

            private set
            {
                if (value >= Console.WindowWidth - (Console.WindowWidth / 4))
                {
                    throw new ArgumentException("Message of the used letters is more than necessary symbols!");
                }

                this.leftMessageGuessedLetters = value;
            }
        }

        /// <summary>
        /// Property for left start position of the users command input
        /// </summary>
        public int LeftPositionCommandInput
        {
            get
            {
                return this.leftPositionCommandInput;
            }

            private set
            {
                if (value <= Console.WindowWidth / 2)
                {
                    throw new ArgumentException("Printed Message is more than necessary symbols!");
                }

                this.leftPositionCommandInput = value;
            }
        }

        /// <summary>
        /// Initialize Console method
        /// </summary>
        public void Initialize()
        {
            Console.WindowHeight = this.initialConsoleHeight;
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
                case "NewLine":
                    this.PrintLine(message);
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

            for (int i = 0; i < options.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - (options[i].Length / 2), this.topOptionsPrint + (2 * i));

                if (i == options.Count - 1)
                {
                    Console.Write(options[i]);
                }
                else
                {
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
            Console.SetCursorPosition(this.LeftMessageGuessedLetters, this.topGuessedLetters);
            Console.WriteLine(Messages.UsedLettersMessage);

            var lettersAsString = string.Join(", ", letters);
            this.LeftGuessedLetters = Console.WindowWidth - (Console.WindowWidth / 4) - (lettersAsString.Length / 2);
            var topLetters = this.topGuessedLetters + 2;
            Console.SetCursorPosition(this.LeftGuessedLetters, topLetters);
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
        /// Prints message on the next line in the console
        /// </summary>
        /// <param name="message"></param>
        public void PrintLine(string message)
        {
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth / 2) - (message.Length / 2), Console.CursorTop + 1);
            Console.Write(message);
        }

        /// <summary>
        /// Print game title on console.
        /// </summary>
        public void PrintGameTitle()
        {
            Console.Clear();
            for (int i = 0; i < Messages.GameTitle.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.GameTitle[i].Length / 2), Console.CursorTop);
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
        }

        /// <summary>
        /// Print message on console.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public void PrintMessage(string message)
        {
            this.LeftPositionCommandInput = this.leftSideCenterPoint - (message.Length / 2);
            Console.SetCursorPosition(this.LeftPositionCommandInput, this.topPositionCommandInput);
            Console.Write(message);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Print hidden word.
        /// </summary>
        /// <param name="hiddenWord">Word to print hidden.</param>
        public void PrintSecretWord(string hiddenWord)
        {
            this.LeftPositionSecretWord = Console.WindowWidth - (Console.WindowWidth / 4) - (Messages.SecretWord.Length / 2);
            Console.SetCursorPosition(this.LeftPositionSecretWord, this.topSecretWord);
            Console.WriteLine(Messages.SecretWord);

            this.LeftPositionSecretWord = Console.WindowWidth - (Console.WindowWidth / 4) - hiddenWord.Length;
            Console.SetCursorPosition(this.LeftPositionSecretWord, this.topSecretWord + 2);
            Console.WriteLine(string.Join(" ", hiddenWord.ToCharArray()));
        }

        /// <summary>
        /// Print hangman. Different hangman depends on playerLives.
        /// </summary>
        /// <param name="playerLives">How many lives player have.</param>
        public void PrintHangman(int playerLives)
        {
            var playerPattern = HangmanPattern.Patterns[playerLives];

            Console.SetCursorPosition(1, this.topHangman);
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
            for (int i = this.topVerticalLine; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.WriteLine("|");
            }
        }

        /// <summary>
        /// Show on user where can write on console.
        /// </summary>
        public void PrintEnterCommandMessage()
        {
            this.LeftPositionCommandInput = this.leftSideCenterPoint - (Messages.EnterLetterMessage.Length / 2);

            Console.SetCursorPosition(this.LeftPositionCommandInput, this.topPositionEnterCommandMsg);
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
            ConsoleHelper.ClearConsoleInRange(this.leftSideCenterPoint, this.leftSideCenterPoint + (Console.WindowWidth / 4) - 1, this.topPositionEnterCommandMsg + 2);
            Console.SetCursorPosition(this.leftSideCenterPoint, this.topPositionEnterCommandMsg + 2);
            var input = Console.ReadLine().ToLower();
            return input;
        }
    }
}