namespace HQC.Project.Hangman2.Players.Common
{
    using System.Collections.Generic;

    public interface IPlayer
    {
        string Name { get; set; }

        int Mistakes { get; set; }

        int Lives { get; set; }

        string Word { get; set; }
        
        ISet<char> WrongLetters { get; set; }

        string HiddenWord { get; }

        void HideWord();

        bool InitializationAfterTheGuess(char supposedChar);

        int Compare(IPlayer otherPlayer);
    }
}
