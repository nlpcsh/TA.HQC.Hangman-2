namespace HQC.Project.Hangman2._1
{
    public class Hangman
    {
        private static void Main(string[] args)
        {
            Printer.PrintWellcomeMessage();
            Printer.PrintOptionsMessage();

            var newGame = new GameEngine();
            newGame.NewGame();
        }
    }
}