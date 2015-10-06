// <copyright file="WordSelectorFromFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Importers
{
    using System;
    using System.IO;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Importers.Common;

    /// <summary>
    /// ???
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
        /// <param name="fileName">???</param>
        public WordSelectorFromFile(string fileName)
        {
            this.FileName = fileName;
            this.RandomWord = this.SelectRandomWord();
        }

        /// <summary>
        /// ???
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        public string RandomWord { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        /// <returns>???</returns>
        public string SelectRandomWord()
        {
            this.inputFileStream = new FileStream(this.FileName, FileMode.Open);
            this.streamReader = new StreamReader(this.inputFileStream);
            string randomWord = string.Empty;

            // determine extent of source file
            long lastPos = this.streamReader.BaseStream.Seek(0, SeekOrigin.End);

            // generate a random position
            double randomNumber = this.GetRandomNumber();
            long randomPositionFromFile = (long)(randomNumber * lastPos);

            if (randomNumber >= 0.99)
            {
                randomPositionFromFile -= 1024; // if near the end, back up a bit
            }

            this.streamReader.BaseStream.Seek(randomPositionFromFile, SeekOrigin.Begin);

            randomWord = this.streamReader.ReadLine(); // consume curr partial line
            randomWord = this.streamReader.ReadLine(); // this will be a full line
            this.streamReader.DiscardBufferedData(); // magic

            this.streamReader.Close();
            this.inputFileStream.Close();

            return randomWord;
        }

        private double GetRandomNumber()
        {
            return random.NextDouble();
        }
    }
}
