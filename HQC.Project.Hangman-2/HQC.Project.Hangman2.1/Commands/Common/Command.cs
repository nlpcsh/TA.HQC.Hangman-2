namespace HQC.Project.Hangman2._1.Commands.Common
{
    using HQC.Project.Hangman;

    public abstract class Command : ICommand
    {
        public abstract void Execute();
    }
}
