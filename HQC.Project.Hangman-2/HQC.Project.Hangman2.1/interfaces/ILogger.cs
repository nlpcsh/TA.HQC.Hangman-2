using System.Collections.Generic;
namespace HQC.Project.Hangman.Interfaces
{
    public interface ILogger
    {
        void LogLine(string logger);

        void PrintGameTitle();

        void PrintOptionsMessage();

        void PrintSecretWord(string hiddenWord);

        void PrintGoodBuyMessage();

        void PrintMessage(string message);

        void PrintHangman(int playerLives);

        void PrintVerticalMiddleBorder();

        void PrintEnterCommandMessage();

        void PrintUsedLetters(ISet<char> letters);

        void PrintGameInitialization();

        void PrintMenu();
    }

}
