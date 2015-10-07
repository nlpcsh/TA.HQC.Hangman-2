namespace HQC.Project.Hangman2._1.Exporters
{
    /// <summary>
    /// Responsible for exporting data.
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="name">Path to place where data will be exported.</param>
        void Save(string name);
    }
}
