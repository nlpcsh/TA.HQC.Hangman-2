namespace HQC.Project.Hangman2._1.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Commands.Common;
    using HQC.Project.Hangman2._1.GameStates;

    public class RestartCommand : Command
    {
        private GameEngine game;

        public RestartCommand(GameEngine currentGame)
        {
            this.game = currentGame;
        }

        public override void Execute()
        {
            this.game.State = new RestartGameState();
            this.game.State.Play(game);
        }
    }
}
