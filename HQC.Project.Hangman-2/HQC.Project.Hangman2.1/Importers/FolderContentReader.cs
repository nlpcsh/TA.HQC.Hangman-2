namespace HQC.Project.Hangman2.Importers
{
    using System.IO;
    using System.Linq;

    using HQC.Project.Hangman.Common;

    public class FolderContentReader
    {     
        public FolderContentReader()
        {
        }

        public string[] Categories
        {
            get
            {
                return this.getCategories();
            }
        }

        private string[] getCategories()
        {
            return Directory.GetFiles(Globals.CategoriesPath, Globals.FileExtension)
                .Select(path => Path.GetFileNameWithoutExtension(path))
                .ToArray();
        }
    }
}
