namespace HQC.Project.Hangman
{
    using System;
    using System.IO;

    public class WordSelector
    {
        private FileStream inputFileStream;
        private StreamReader streamReader;
        
        public string SelectRandomWord(string path)
        {
            inputFileStream = new FileStream(path, FileMode.Open);
            streamReader = new StreamReader(inputFileStream);
            string randomWord = "";

            // determine extent of source file
            long lastPos = streamReader.BaseStream.Seek(0, SeekOrigin.End);

            // generate a random position
            double randomNumber = GetRandomNumber();
            long randomPositionFromFile = (long)(randomNumber * lastPos);

            if (randomNumber >= 0.99)
            {
                randomPositionFromFile -= 1024; // if near the end, back up a bit
            }

            streamReader.BaseStream.Seek(randomPositionFromFile, SeekOrigin.Begin);

            randomWord = streamReader.ReadLine(); // consume curr partial line
            randomWord = streamReader.ReadLine(); // this will be a full line
            streamReader.DiscardBufferedData(); // magic

            streamReader.Close();
            inputFileStream.Close();

            return randomWord;
        }

        private double GetRandomNumber()
        {
            Random random = new Random();
            return random.NextDouble();
        }
    }
}
