namespace HQC.Project.Hangman2.GameStates
{
    using System;

    using HQC.Project.Hangman;

    public class RestartGameState : State
    {
        public override void Play(GameEngine game)
        {
            Console.Clear();
            game.Logger.PrintGameTitle();

            Console.Write("Want to play again? y/n ");
            char playAgainYesNo = Console.ReadKey().KeyChar;

            Console.WriteLine();

            if (playAgainYesNo == 'y')
            {
                game.State = new MenuState();
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
