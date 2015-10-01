namespace HQC.Project.Hangman2.GameStates
{
    using System;

    using HQC.Project.Hangman2.Importers;

    public class ChooseCategoryState : GameState
    {
        public override void Play(Hangman.GameEngine game)
        {
            Console.Clear();

            var contentReader = new FolderContentReader();
            
            game.Logger.PrintCategories(contentReader.getCategories());

            // should display only categories for now (it is still unreachable)

        }
    }
}
