﻿// <copyright file="ChooseCategoryState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Importers;

    /// <summary>
    /// ???
    /// </summary>
    public class ChooseCategoryState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(GameEngine game)
        {
            var contentReader = new FolderContentReader();

            game.Logger.PrintCategories(contentReader.Categories);
            string chosenCategory = Console.ReadLine().Trim().ToLower();

            bool categoryExists = this.CategoriesToLower(contentReader.Categories).Contains(chosenCategory.ToLower());

            if (categoryExists)
            {
                game.WordSelect.FileName = "../../Words/" + chosenCategory + Globals.FileExtension;
            }
            else
            {
                game.WordSelect.FileName = "../../Words/Random" + Globals.FileExtension;
            }

            game.State = new InitializeGameState();
            game.State.Play(game);
        }

        private ICollection<string> CategoriesToLower(string[] categories)
        {
            var categoriesToLower = new List<string>();

            foreach (var category in categories)
            {
                categoriesToLower.Add(category.ToLower());
            }

            return categoriesToLower;
        }
    }
}
