// <copyright file="ChooseCategoryState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using System.Collections.Generic;

    using Common;
    using Hangman.Common;
    using Importers;

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
            string[] categoriesToList = contentReader.GetCategories(Globals.CategoriesPath, "*" + Globals.FileExtension);
            game.UI.Print(categoriesToList);
            game.UI.Print(Messages.EnterChoiceMessage, "NewLine");

            string chosenCategory = game.UI.ReadLine();

            bool categoryExists = this.CategoriesToLower(categoriesToList).Contains(chosenCategory.ToLower());

            if (categoryExists)
            {
                game.WordSelect.FileName = "../../Words/" + chosenCategory + Globals.FileExtension;
            }
            else
            {
                game.UI.Print(Messages.WrongCommand, "NewLine");

                this.Play(game);
            }

            game.State = new InitializeGameState();
            game.State.Play(game);
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
