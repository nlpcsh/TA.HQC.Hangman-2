namespace HQC.Project.Hangman.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for UI
    /// </summary>
    public interface IUI
    {
        /// <summary>
        /// Initialize Game UI
        /// </summary>
        void Initialize();

        /// <summary>
        /// ReInitialize Game UI
        /// </summary>
        void ReInitizlize();

        /// <summary>
        /// Prints message and use second parameter for additional info as - where to print
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        void Print(string message, string position);

        /// <summary>
        /// Prints List of strings
        /// </summary>
        /// <param name="listMessage"></param>
        void Print(IList<string> listMessage);

        /// <summary>
        /// Prints List of chars
        /// </summary>
        /// <param name="letters"></param>
        void Print(ISet<char> letters);

        /// <summary>
        /// Reads input from line
        /// </summary>
        /// <returns></returns>
        string ReadLine();

        /// <summary>
        /// Reads input as char
        /// </summary>
        /// <returns></returns>
        char ReadKey();

        /// <summary>
        /// Reads input key from user
        /// </summary>
        /// <returns></returns>
        string ReadKeyInput();
    }
}
