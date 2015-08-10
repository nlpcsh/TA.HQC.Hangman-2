namespace HQC.Project.Hangman2._1
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;

    public class Hangman
    {
        private static bool gameIsOn = true;

        static void Main(string[] args)
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
