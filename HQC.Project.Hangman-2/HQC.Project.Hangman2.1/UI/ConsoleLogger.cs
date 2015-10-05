﻿// <copyright file="ConsoleLogger.cs" company="PlaceholderCompany">
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
        private int commandMessageTopPosition = Globals.TopPositionCommandInput + 2;

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="line">???</param>
        public void LogLine(string line)
        {
            Console.WriteLine(line);
        }

        /// <summary>
        /// ???
        /// </summary>
        public void PrintGameTitle()
        {
            var title = new StringBuilder();

            title.AppendLine("00  00     000     00    00  0000   00     00     000     00    00");
            title.AppendLine("00  00    00 00    0000  00 00      0000 0000    00 00    0000  00");
            title.AppendLine("000000   0000000   00 00 00 00 0000 00 000 00   0000000   00 00 00");
            title.AppendLine("00  00  00     00  00   000 00   00 00  0  00  00     00  00   000");
            title.AppendLine("00  00 00       00 00    00  00000  00     00 00       00 00    00");

            Console.WriteLine(title.ToString().Trim());
            Console.WriteLine(new string('_', Console.BufferWidth));
            Console.WriteLine(new string('-', Console.BufferWidth));
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
            Console.SetCursorPosition(Globals.LeftPositionCommandInput - (message.Length / 2), this.commandMessageTopPosition);
            Console.WriteLine(message);
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
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
            var heigth = (Console.WindowHeight / 2) - (playerPattern.Length / 9);

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
        public void PrintMenu()
        {
            Console.Clear();
            this.PrintGameTitle();
            var top = (Console.WindowHeight / 2) - 6;
            var left = (Console.WindowWidth / 2) - ("MENU".Length / 2);
            Console.SetCursorPosition(left, top);
            Console.WriteLine("MENU:");

            left = (Console.WindowWidth / 2) - (("MENU".Length + 2) / 2);
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine("------");

            left = (Console.WindowWidth / 2) - ("PLAY".Length / 2);
            Console.SetCursorPosition(left, top + 3);
            Console.WriteLine("PLAY");

            left = (Console.WindowWidth / 2) - ("RULES".Length / 2);
            Console.SetCursorPosition(left, top + 5);
            Console.WriteLine("RULES");

            left = (Console.WindowWidth / 2) - ("SCORES".Length / 2);
            Console.SetCursorPosition(left, top + 7);
            Console.WriteLine("SCORES");

            left = (Console.WindowWidth / 2) - ("EXIT".Length / 2);
            Console.SetCursorPosition(left, top + 9);
            Console.WriteLine("EXIT");

            left = (Console.WindowWidth / 2) - ("Enter your choice:".Length / 2);
            Console.SetCursorPosition(left, top + 11);
            Console.Write("Enter your choice:");
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="categories">???</param>
        public void PrintCategories(string[] categories)
        {
            Console.Clear();
            this.PrintGameTitle();
            var top = Console.WindowHeight / 3;
            var left = Console.WindowWidth / 2;
            Console.SetCursorPosition(left - (Messages.Categories.Length / 2), top);
            Console.WriteLine(Messages.Categories);

            top++;
            foreach (var category in categories)
            {
                top += 1;
                Console.SetCursorPosition(left - (category.Length / 2), top);
                Console.WriteLine(category);
            }

            Console.SetCursorPosition(left - (Messages.PressToContinue.Length / 2), top + 3);
            Console.Write(Messages.PressToContinue);

            Console.SetCursorPosition(left - (Messages.EnterChoiceMessage.Length / 2), top + 2);
            Console.Write(Messages.EnterChoiceMessage);
        }

        /// <summary>
        /// ???
        /// </summary>
        public void PrintMenuHelpOption()
        {
            var startCol = (Console.WindowWidth / 2) - (Messages.EnterChoiceMessage.Length / 2);
            var endCol = (Console.WindowWidth / 2) + Messages.EnterChoiceMessage.Length;
            var top = (Console.WindowHeight / 2) - 6;
            ConsoleHelper.ClearConsoleInRange(startCol, endCol, top, top + 12);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.WelcomeMessage.Length / 2), top);
            Console.WriteLine(Messages.WelcomeMessage);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.RulesMessage.Length / 2), top + 2);
            Console.WriteLine(Messages.RulesMessage);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.BonusMenuMessagePart1.Length / 2), top + 4);
            Console.WriteLine(Messages.BonusMenuMessagePart1);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.BonusMenuMessagePart2.Length / 2), top + 5);
            Console.WriteLine(Messages.BonusMenuMessagePart2);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.HelpCommandMessagePart1.Length / 2), top + 7);
            Console.WriteLine(Messages.HelpCommandMessagePart1);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.HelpCommandMessagePart2.Length / 2), top + 8);
            Console.WriteLine(Messages.HelpCommandMessagePart2);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.EnjoyMessage.Length / 2), top + 10);
            Console.WriteLine(Messages.EnjoyMessage);

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.PressAnyKeyMessage.Length / 2), (Console.WindowHeight / 2) + 10);
            Console.WriteLine(Messages.PressAnyKeyMessage);
            Console.ReadLine();
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="topPlayers">???</param>
        public void PrintBestScores(IList<IPlayer> topPlayers)
        {
            Console.Clear();
            this.PrintGameTitle();
            var top = (Console.WindowHeight / 2) - 6;

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.BestScores.Length / 2), top);
            Console.WriteLine(Messages.BestScores);

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (topPlayers[i] != null && topPlayers[i].Name != Globals.NoPlayer)
                {
                    string places = string.Format("{0}. {1} ---> {2}", i + 1, topPlayers[i].Name, topPlayers[i].Mistakes);
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (places.Length / 2), top + (2 * i) + 2);
                    Console.WriteLine(places);
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("No Scores");
                    }

                    break;
                }
            }

            Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.PressAnyKeyMessage.Length / 2), (Console.WindowHeight / 2) + 7);
            Console.WriteLine(Messages.PressAnyKeyMessage);
            Console.ReadLine();
        }
    }
}