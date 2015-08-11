namespace HQC.Project.Hangman2._1
{
    using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;

    public class CommandManager
    {
        public void Restart()
        {
            var newGame = new GameEngine();
            newGame.NewGame();
        }

        public void Exit()
        {
            //Console.WriteLine("Good bye!");
            Printer.PrintGoodBuyMessage();
            GameEngine.gameIsOn = false;

            Environment.Exit(0);
        }
    }
}
