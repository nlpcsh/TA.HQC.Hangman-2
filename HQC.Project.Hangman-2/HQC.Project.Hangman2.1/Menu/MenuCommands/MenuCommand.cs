namespace HQC.Project.Hangman2.Commands.MenuCommands
{
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;

    public abstract class MenuCommand : ICommand
    {
        public MenuCommand(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger { get; set; }

        public abstract void Execute();

    }
}
