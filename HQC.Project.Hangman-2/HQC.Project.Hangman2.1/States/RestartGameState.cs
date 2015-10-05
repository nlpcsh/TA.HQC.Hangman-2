﻿// <copyright file="RestartGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using HQC.Project.Hangman;

    /// <summary>
    /// ???
    /// </summary>
    public class RestartGameState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(HangmanGame game)
        {
            Console.Clear();
            game.Logger.PrintGameTitle();

            Console.Write("Want to play again? y/n ");
            char playAgainYesNo = Console.ReadKey().KeyChar;

            Console.WriteLine();

            if (playAgainYesNo == 'y')
            {
                game.State = new ChooseCategoryState();
                game.State.Play(game);
            }
            else
            {
                // Execute.Exit();
                game.Logger.PrintGoodBuyMessage();
                Environment.Exit(0);
            }
        }
    }
}
