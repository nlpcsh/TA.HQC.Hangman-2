namespace HQC.Project.Hangman
{
    using System;
    using System.Linq;

    public class WordSelector
    {
        private string[] words =
                                {
                                    "computer", "programmer", "software", "debugger", "compiler",
                                    "developer", "algorithm", "array", "method", "variable"
                                };

        public string SelectRandomWord()
        {
            int randomWordPosition = this.GetRandomNumber(0, this.words.Length);
            string randomlySelectedWord = this.words.ElementAt(randomWordPosition);

            return randomlySelectedWord;
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
