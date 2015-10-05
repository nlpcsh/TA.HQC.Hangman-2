namespace HQC.Project.Hangman2
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman2.Commands.Common;

    public abstract class GameCommand : Command
    {
        public GameCommand(GameEngine game)
            : base(game)
        {
        }
    }
}
