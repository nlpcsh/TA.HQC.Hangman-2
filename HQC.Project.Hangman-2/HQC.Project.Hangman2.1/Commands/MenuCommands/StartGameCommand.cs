namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;

    public class StartGameCommand : HQC.Project.Hangman2._1.MenuCommand
    {
        public StartGameCommand(GameEngine currentGame)
            : base(currentGame)
        {
        }

        public override void Execute()
        {
            this.Game.State = new InitializeGameState();
            this.Game.State.Play(this.Game);
        }
    }
}