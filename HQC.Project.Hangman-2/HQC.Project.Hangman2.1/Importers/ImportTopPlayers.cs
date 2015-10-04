namespace HQC.Project.Hangman2.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HQC.Project.Hangman2.Importers.Common;
    using HQC.Project.Hangman2.Players.Common;
    using HQC.Project.Hangman.Players;
    using System.IO;
    using HQC.Project.Hangman.Common;

    public class ImportTopPlayers : IPlayesImporter
    {
        private IList<IPlayer> topPlayers = new List<IPlayer>();

        public IList<IPlayer> TopPlayers { get; set; }
        public ImportTopPlayers(string fileName)
        {
            this.TopPlayers = ImportPlayers(fileName);
        }
        public IList<IPlayer> ImportPlayers(string fileName)
        {
            var scoreBoardTable = new Player[Globals.ScoreBoardSize];
            using (var reader = new StreamReader(fileName))
            {
                var score = reader.ReadLine();
                var index = 0;

                while (score != null)
                {
                    string playerName;
                    int playerScore;

                    if (score == Globals.FreePositionInScoreBoars)
                    {
                        playerName = "No Player";
                        playerScore = int.MaxValue;
                    }
                    else
                    {
                        var separateScore = score.Split('-');
                        playerName = separateScore[0].Trim();
                        playerScore = int.Parse(separateScore[1]);
                    }

                    scoreBoardTable[index] = new Player(playerName, playerScore);
                    score = reader.ReadLine();
                    index++;
                }
            }

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (scoreBoardTable[i] == null)
                {
                    scoreBoardTable[i] = new Player(Globals.NoPlayer, int.MaxValue);
                }
            }

            return scoreBoardTable;
        }
    }
}
