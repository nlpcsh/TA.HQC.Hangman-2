namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;
    using HQC.Project.Hangman2._1.GameStates;

    public class PlayCommand : Command
    {
        private GameEngine game;

        public PlayCommand(GameEngine currentGame)
        {
            this.game = currentGame;
        }

        public override void Execute()
        {
            game.State = new InitializeGameState();
            game.State.Play(game);
        }
    }
}