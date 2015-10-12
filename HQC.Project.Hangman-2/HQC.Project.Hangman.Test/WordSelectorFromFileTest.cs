namespace HQC.Project.Hangman.Test
{
    using System;
    using Common;
    using Importers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WordSelectorFromFileTest
    {
        [TestMethod]
        public void ExpectToWorkWhenInvalidPathForSecretsWordsIsProvided()
        {
            var wordSelector = new WordSelectorFromFile();
            wordSelector.FileName = @"..\..\testBestScores\bestScoresTest1.txt";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectToThrowWhenInvalidPathForSecretsWordsIsProvided()
        {
            var wordSelector = new WordSelectorFromFile();
            wordSelector.FileName = @"..\..\HQC.Project.Hangman2.1\" + Globals.CategoriesPath + "notIT.txt";
        }
    }
}
