﻿// <copyright file="PlayerInitializationState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.GameLogic.States;
    using HQC.Project.Hangman.GameLogic.States.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class PlayerInitializationState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(HangmanGame game)
        {
            Console.Clear();
            game.Logger.PrintGameTitle();
            game.Logger.PrintGameInitialization();

            string name = Console.ReadLine();
            var playerName = string.IsNullOrWhiteSpace(name) ? "unknown" : name;
            game.Player.Name = playerName;
            game.Player.Score = 0;

            game.State = new ChooseCategoryState();
            game.State.Play(game);
        }
    }
}