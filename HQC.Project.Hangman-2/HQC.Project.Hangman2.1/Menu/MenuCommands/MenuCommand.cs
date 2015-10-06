namespace HQC.Project.Hangman.Menu.MenuCommands
{
    using HQC.Project.Hangman.Contracts;
    using HQC.Project.Hangman.UI.Common;

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
