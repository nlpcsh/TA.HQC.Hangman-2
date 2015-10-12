// <copyright file="WordSelectorFromFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Importers
{
    using System;
    using System.IO;

    using Common;

    /// <summary>
    /// Responsible for exporting word from file.
    /// </summary>
    public class WordSelectorFromFile : IWordsImporter
    {
        private static Random random = new Random();
        private FileStream inputFileStream;
        private StreamReader streamReader;
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordSelectorFromFile"/> class.
        /// </summary>
        public WordSelectorFromFile()
        {
        }

        /// <summary>
        /// File name. Makes check if file name is valid.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                if (!this.IsValidFilename(value))
                {
                    throw new ArgumentException("Invalid file path!");
                }

                if (!File.Exists(value))
                {
                    throw new ArgumentException("Category secret word file don't exist!");
                }

                this.fileName = value;
            }
        }

        /// <summary>
        /// Performs algorithm for selecting random word from file.
        /// </summary>
        /// <returns>Random word from file.</returns>
        public string SelectRandomWord()
        {
            string randomWord = string.Empty;

            using (this.inputFileStream = new FileStream(this.FileName, FileMode.Open))
            {
                this.streamReader = new StreamReader(this.inputFileStream);

                // determine extent of source file
                long lastPos = this.streamReader.BaseStream.Seek(0, SeekOrigin.End);

                double randomNumber = this.GetRandomNumber();
                long randomPositionFromFile = (long)(randomNumber * lastPos);

                if (randomNumber >= 0.99)
                {
                    randomPositionFromFile -= 1024; // if near the end, back up a bit
                }

                this.streamReader.BaseStream.Seek(randomPositionFromFile, SeekOrigin.Begin);

                randomWord = this.streamReader.ReadLine();
                randomWord = this.streamReader.ReadLine();
                this.streamReader.DiscardBufferedData();

                this.streamReader.Close();
            }

            return randomWord;
        }

        private double GetRandomNumber()
        {
            return random.NextDouble();
        }

        private bool IsValidFilename(string filePath)
        {
            bool containsABadCharacter = filePath.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;
            if (containsABadCharacter)
            {
                return true;
            }

            return false;
        }
    }
}
