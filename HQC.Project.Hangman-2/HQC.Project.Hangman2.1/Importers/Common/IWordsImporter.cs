namespace HQC.Project.Hangman.Importers.Common
{
    /// <summary>
    /// Responsible for importing words.
    /// </summary>
    public interface IWordsImporter
    {
        /// <summary>
        /// Imports word on random algorithm.
        /// </summary>
        /// <returns>Random word.</returns>
        string SelectRandomWord();
    }
}
