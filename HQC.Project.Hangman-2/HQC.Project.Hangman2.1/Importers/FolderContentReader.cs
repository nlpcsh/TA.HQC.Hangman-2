// <copyright file="FolderContentReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Importers
{
    using System.IO;
    using System.Linq;

    using HQC.Project.Hangman.Common;

    /// <summary>
    /// ???
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
        /// ???
        /// </summary>
        public string[] Categories
        {
            get
            {
                return this.GetCategories();
            }
        }

        private string[] GetCategories()
        {
            return Directory.GetFiles(Globals.CategoriesPath, "*" + Globals.FileExtension)
                .Select(path => Path.GetFileNameWithoutExtension(path))
                .ToArray();
        }
    }
}
