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
            Console.Clear();

            var contentReader = new FolderContentReader();
            
            Console.WriteLine("Choose Category!");
            
            game.Logger.PrintCategories(contentReader.Categories);
            
            //string chosenCategory = Console.ReadLine().Trim().ToLower();
            //string categoryPath = "../../Words/" + chosenCategory + ".txt";
            //game.WordSelect.FileName = categoryPath;
            
            Console.WriteLine();
            Console.WriteLine("Now working yet, 3 seconds untill redirect!");
            Thread.Sleep(3000);
            
            game.State = new PlayerInitializationState();
            game.State.Play(game);
            

        }
    }
}
