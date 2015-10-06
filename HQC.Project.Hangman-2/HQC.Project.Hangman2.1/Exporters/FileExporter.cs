namespace HQC.Project.Hangman2._1.Exporters
{
    using System.IO;
    using System.Linq;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.Importers;

    /// <summary>
    /// ???
    /// </summary>
    public class FileExporter : IExporter
    {
        private ImportTopPlayersFromFile players;

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="players">???</param>
        public FileExporter(ImportTopPlayersFromFile players) 
        {
            this.players = players;
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="filename">???</param>
        public void Save(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                var sortedScores = this.players.TopPlayers.OrderBy(x => x.Score);

                foreach (var score in sortedScores)
                {
                    if (score == null)
                    {
                        writer.WriteLine(Globals.FreePositionInScoreBoars);
                    }
                    else
                    {
                        writer.WriteLine(score.Name + "-" + score.Score);
                    }
                }
            }
        }
    }
}
