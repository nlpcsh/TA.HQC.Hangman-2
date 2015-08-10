namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Linq;

    internal class WordSelector
    {
        private string[] words =
                                        { 
                                            "computer", "programmer", "software", "debugger", "compiler", 
                                            "developer", "algorithm", "array", "method", "variable"
                                        };

        public string SelectRandomWord()
        {
            int randomWordPosition = GetRandomNumber(0, words.Length);
            string randomlySelectedWord = words.ElementAt(randomWordPosition);

            return randomlySelectedWord;
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
