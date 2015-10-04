namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;

    public class RestartCommand : HQC.Project.Hangman2._1.GameCommand
    {
        public RestartCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.State = new RestartGameState();
            this.Game.State.Play(this.Game);
        }
    }
}
