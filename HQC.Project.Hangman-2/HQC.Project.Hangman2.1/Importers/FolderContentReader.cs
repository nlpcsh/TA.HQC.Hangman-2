namespace HQC.Project.Hangman2.Importers
{
    using System.IO;
    using System.Linq;

    using HQC.Project.Hangman.Common;

    public class FolderContentReader
    {
        private readonly string fileExtension = "*.TXT";
        
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

        public string[] getCategories()
        {
            return Directory.GetFiles(Globals.CategoriesPath, fileExtension)
                .Select(path => Path.GetFileNameWithoutExtension(path))
                .ToArray();
        }
    }
}
