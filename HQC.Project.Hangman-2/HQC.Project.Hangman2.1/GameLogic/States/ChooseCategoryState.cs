// <copyright file="ChooseCategoryState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.GameLogic.States.Common;
    using HQC.Project.Hangman.Importers;

    /// <summary>
    /// This class initializes a state in the game, where you can choose category of words. In case you choose an invalid category, the category "Random" is automatically chosen.
    /// </summary>
    public class ChooseCategoryState : State
    {
        /// <summary>
        /// Initializes category choosing.
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public override void Play(HangmanGame game)
        {
            var contentReader = new FolderContentReader();
            var categoriesToList = this.GetAllCategories(contentReader);
            game.Logger.Print(categoriesToList);

            string chosenCategory = Console.ReadLine().Trim().ToLower();
            bool categoryExists = this.CategoriesToLower(contentReader.Categories).Contains(chosenCategory.ToLower());

            if (categoryExists)
            {
                game.WordSelect.FileName = "../../Words/" + chosenCategory + Globals.FileExtension;
            }
            else
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - (Messages.WrongCommand.Length / 2), Console.WindowHeight - 2);
                Console.WriteLine(Messages.WrongCommand);
                Thread.Sleep(500);
                this.Play(game);
            }

            game.State = new InitializeGameState();
            game.State.Play(game);
        }

        /// <summary>
        /// Get all categories from .txt file
        /// </summary>
        /// <param name="contentReader">All files in this directory</param>
        /// <returns>List with all categories in content reader</returns>
        private IList<string> GetAllCategories(FolderContentReader contentReader)
        {
            var categories = contentReader.Categories;
            var categoriesToList = new List<string>();

            categoriesToList.Add(Messages.Categories);
            for (int i = 0; i < categories.Length; i++)
            {
                categoriesToList.Add(categories[i]);
            }

            categoriesToList.Add(Messages.EnterChoiceMessage);

            return categoriesToList;
        }

        /// <summary>
        /// Transform categories to lower case letters
        /// </summary>
        /// <param name="categories">All categories</param>
        /// <returns>ICollection with all categories with small letters</returns>
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
