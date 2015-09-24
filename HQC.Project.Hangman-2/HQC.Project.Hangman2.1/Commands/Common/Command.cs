namespace HQC.Project.Hangman2._1.Commands.Common
{
    using HQC.Project.Hangman;

    public abstract class Command : ICommand
    {
        public Command(GameEngine currentGame)
        {
            this.Game = currentGame;
        }

        protected GameEngine Game { get;  set; }

        public abstract void Execute();
    }
}
