namespace HQC.Project.Hangman
{
    using System;
    using System.IO;

    public class WordSelectorFromFile
    {
        private static Random random = new Random();
        private FileStream inputFileStream;
        private StreamReader streamReader;
        private string fileName;
        private string randomWord;

        public WordSelectorFromFile(string fileName) 
        {
            this.FileName = fileName;
            this.randomWord = SelectRandomWord();
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set 
            {
                // add validation on file name
                this.fileName = value;
            }
        }

        public string RandomWord { get; set; }
        private string SelectRandomWord()
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
