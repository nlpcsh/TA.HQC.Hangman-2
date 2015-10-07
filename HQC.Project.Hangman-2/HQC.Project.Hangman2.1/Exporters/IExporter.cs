// <copyright file="IExporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Exporters
{
    /// <summary>
    /// Responsible for exporting data.
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="name">Path to place where data will be exported.</param>
        void Save(string name);
    }
}
