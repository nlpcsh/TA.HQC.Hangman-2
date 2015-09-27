namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.UI;

    public class Hangman
    {
        private static void Main(string[] args)
        {
            var newGame = new GameEngine(new ConsoleLogger());
            newGame.NewGame();
        }
    }
}