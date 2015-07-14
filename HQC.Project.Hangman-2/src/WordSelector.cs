namespace HQC.Project.Hangman2
{
    using System;
    using System.Linq;

    class WordSelector
    {
        //why public
        private static string[] words = {"computer", "programmer", "software", "debugger", "compiler",
            "developer", "algorithm", "array", "method", "variable" };
            
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string SelectRandomWord()
        {
            int randomPositionOfTheWordToBeSelected = RandomNumber(0, words.Length);
            string randomlySelectedWord = words.ElementAt(randomPositionOfTheWordToBeSelected);
            
            return randomlySelectedWord;
        }
    }
}
