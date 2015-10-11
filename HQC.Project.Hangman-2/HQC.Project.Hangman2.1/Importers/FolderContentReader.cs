// <copyright file="FolderContentReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Importers
{
    using System.IO;
    using System.Linq;

    /// <summary>
    /// This class reads the files in the given directory with the given extension
    /// </summary>
    public class FolderContentReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderContentReader"/> class.
        /// </summary>
        public FolderContentReader()
        {
        }

        /// <summary>
        /// Return an array with string, containing only the names of the files, without their extensions
        /// </summary>
        public string[] GetCategories(string filesPath, string filesExtentions)
        {
            try
            {
                string[] categories = Directory.GetFiles(filesPath, filesExtentions)
                .Select(path => Path.GetFileNameWithoutExtension(path))
                .ToArray();
                return categories;
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Category files are not set properly!");
            }
        }
    }
}
