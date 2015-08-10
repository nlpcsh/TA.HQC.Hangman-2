namespace HQC.Project.Hangman2._1
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;

    public class GameEngine
    {
        private static bool gameIsOn = true;

        internal void NewGame()
        {
            var commantExecutor = new CommandExecuter();
            var scoreBoard = new ScoreBoard();
            var wordSelector = new WordSelector();

            while (gameIsOn)
            {
                var player = new Player();


                gameIsOn = false;
            }
        }
    }
}
