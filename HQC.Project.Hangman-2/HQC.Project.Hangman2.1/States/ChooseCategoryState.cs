namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Linq;
    using System.Threading;

    using HQC.Project.Hangman2.Importers;
    using HQC.Project.Hangman;


    public class ChooseCategoryState : State
    {
        public override void Play(GameEngine game)
        {
            var contentReader = new FolderContentReader();
            
            game.Logger.PrintCategories(contentReader.Categories);
            string chosenCategory = Console.ReadLine().Trim().ToLower();

            if (contentReader.Categories.Contains(chosenCategory))
            {
                game.WordSelect.FileName = "../../Words/" + chosenCategory + ".txt";
            }
            else
            {
                game.WordSelect.FileName = "../../Words/words.txt";
            }
            
            game.State = new InitializeGameState();
            game.State.Play(game);
        }
    }
}
