namespace HQC.Project.Hangman
{
    public class Hangman
    {
        private static void Main(string[] args)
        {
            var newGame = new GameEngine();
            newGame.NewGame();
        }
    }
}