namespace HQC.Project.Hangman.Menu.MenuCommands
{
    using HQC.Project.Hangman.Contracts;
    using HQC.Project.Hangman.UI.Common;

    /// <summary>
    /// ???
    /// </summary>
    public abstract class MenuCommand : ICommand
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="logger">???</param>
        public MenuCommand(ILogger logger)
        {
            this.Logger = logger;
        }

        /// <summary>
        /// ???
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public abstract void Execute();
    }
}
