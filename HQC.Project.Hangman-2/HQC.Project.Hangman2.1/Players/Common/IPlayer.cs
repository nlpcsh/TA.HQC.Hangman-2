using System.Collections.Generic;
namespace HQC.Project.Hangman2._1.Players.Common
{
    public interface IPlayer
    {
        string Name { get; set; }

        int Mistakes { get; set; }

        int Lives { get; set; }

        string Word { get; set; }

        List<char> AllGuessedLetters { get; set; }

        ISet<char> WrongLetters { get; set; }

        string HiddenWord { get; }

        void InitializationOfGame();

        bool InitializationAfterTheGuess(char supposedChar);

        int Compare(IPlayer otherPlayer);
    }
}
