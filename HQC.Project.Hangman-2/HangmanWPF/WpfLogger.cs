using HQC.Project.Hangman.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class WpfLogger : ILogger
    {
        public void PrintGameTitle()
        {
        }

        public void PrintGoodBuyMessage()
        {
            throw new NotImplementedException();
        }

        public void PrintMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void PrintSecretWord(string hiddenWord)
        {
            throw new NotImplementedException();
        }

        public void PrintHangman(int playerLives)
        {
            throw new NotImplementedException();
        }

        public void PrintVerticalMiddleBorder()
        {
            throw new NotImplementedException();
        }

        public void PrintEnterCommandMessage()
        {
            throw new NotImplementedException();
        }

        public void PrintUsedLetters(ISet<char> letters)
        {
            throw new NotImplementedException();
        }

        public void PrintGameInitialization()
        {
            throw new NotImplementedException();
        }

        public void Print(List<string> options)
        {
            throw new NotImplementedException();
        }

        public string ReadInput()
        {
            throw new NotImplementedException();
        }
    }
}
