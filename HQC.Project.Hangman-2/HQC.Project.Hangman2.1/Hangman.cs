namespace HQC.Project.Hangman
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