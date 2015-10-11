namespace HQC.Project.Hangman.Test
{
    using System.IO;

    using Common;
    using Importers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
 
    [TestClass]
    public class FolderContentReaderTest
    {
        [TestMethod]
        public void ExpectToReturnCathegoriesWhenWrightPathIsProvided()
        {
            var contentReader = new FolderContentReader();
            var categoriesList = contentReader.GetCategories(@"..\..\..\HQC.Project.Hangman2.1\bin" + Globals.CategoriesPath, "*" + Globals.FileExtension);

            string[] allCategories = 
                {
                    "Animals", "CarManufacturers", "Countries",
                    "EgyptianGods", "Fruits", "GreekMythology",
                    "IT", "Philosophers", "Random", "Space", "Vegetables"
                };
            Assert.AreEqual(allCategories.Length, categoriesList.Length);

            for (int i = 0; i < allCategories.Length; i++)
            {
                Assert.IsTrue(allCategories[i].Contains(categoriesList[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ExpectToThrowWhenWrongPathToCathegoryListIsProvided()
        {
            var contentReader = new FolderContentReader();
            var categoriesList = contentReader.GetCategories(Globals.CategoriesPath, "*" + Globals.FileExtension);
        }
    }
}
