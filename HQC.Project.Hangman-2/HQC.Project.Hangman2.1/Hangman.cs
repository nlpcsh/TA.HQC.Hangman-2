namespace HQC.Project.Hangman2._1
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;

    public class Hangman
    {
        static void Main(string[] args)
        {
            Printer.PrintWellcomeMessage();
            Printer.PrintOptionsMessage();

            var newGame = new GameEngine();
            newGame.NewGame();
        }
    }
}
