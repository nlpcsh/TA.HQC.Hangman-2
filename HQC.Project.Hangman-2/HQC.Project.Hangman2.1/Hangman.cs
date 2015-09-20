namespace HQC.Project.Hangman
{
    public class Hangman
    {
        private static void Main(string[] args)
        {
            Printer.PrintGameTitle();
            Printer.PrintVerticalMiddleBorder();
            Printer.PrintHangman(0);

            // var newGame = new GameEngine();
            // newGame.NewGame();
        }
    }
}