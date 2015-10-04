namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Collections.Generic;

    using HQC.Project.Hangman2.Importers;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;


    public class ChooseCategoryState : State
    {
        public override void Play(GameEngine game)
        {
            var contentReader = new FolderContentReader();
            
            game.Logger.PrintCategories(contentReader.Categories);
            string chosenCategory = Console.ReadLine().Trim().ToLower();

            bool categoryExists = CategoriesToLower(contentReader.Categories).Contains(chosenCategory.ToLower());

            if(categoryExists)
            {
                game.WordSelect.FileName = "../../Words/" + chosenCategory + ".txt";
            }
            else
            {
                game.WordSelect.FileName = "../../Words/Random.txt";
            }
            
            game.State = new InitializeGameState();
            game.State.Play(game);
        }

        private ICollection<string> CategoriesToLower(string[] categories)
        {
            var categoriesToLower = new List<string>();

            foreach(var category in categories)
            {
                categoriesToLower.Add(category.ToLower());
            }

            return categoriesToLower;
        }
    }
}
