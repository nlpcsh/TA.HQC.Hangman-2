namespace HQC.Project.Hangman.Test
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Importers;

    [TestClass]
    public class ImportTopPlayersFromFileTest
    {
        [TestMethod]
        public void ExpectToWorkWhenFilePathIsOk()
        {
            string filePath = @"..\..\..\HQC.Project.Hangman2.1\bestScores.txt";
            var fileReader = new ImportTopPlayersFromFile(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ExpectToThrowWhenFilePathIsWrong()
        {
            string filePath = @"..\..\..\HQC.Project.Hangman2.1\nofile.non";
            var fileReader = new ImportTopPlayersFromFile(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectToThrowWhenScoresFormatIsWrong()
        {
            string filePath = @"..\..\testBestScores\bestScoresTest1.txt";
            var fileReader = new ImportTopPlayersFromFile(filePath);
            var scores = fileReader.ImportPlayers(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectToThrowWhenScoresIsNotANumber()
        {
            string filePath = @"..\..\testBestScores\bestScoresTest2.txt";
            var fileReader = new ImportTopPlayersFromFile(filePath);
            var scores = fileReader.ImportPlayers(filePath);
        }
    }
}
