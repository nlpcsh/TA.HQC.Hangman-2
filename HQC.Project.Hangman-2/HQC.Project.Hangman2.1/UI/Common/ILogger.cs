namespace HQC.Project.Hangman.UI
{
    using System.Collections.Generic;

    public interface ILogger
    {
        void LogLine(string logger);

        void PrintGameTitle();

        void PrintOptionsControls();

        void PrintGoodBuyMessage();

        void PrintMessage(string message);

        void PrintSecretWord(string hiddenWord);

        void PrintHangman(int playerLives);

        void PrintVerticalMiddleBorder();

        void PrintEnterCommandMessage();

        void PrintUsedLetters(ISet<char> letters);

        void PrintGameInitialization();

        void PrintMenu();
    }

}
