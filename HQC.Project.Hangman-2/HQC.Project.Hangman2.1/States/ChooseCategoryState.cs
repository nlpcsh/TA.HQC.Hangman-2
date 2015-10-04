namespace HQC.Project.Hangman2.GameStates
{
    using System;
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
            game.WordSelect.FileName = "../../Words/" + chosenCategory + ".txt";

            game.State = new PlayerInitializationState();
            game.State.Play(game);
        }
    }
}
