namespace HQC.Project.Hangman2.Importers.Common
{
    using HQC.Project.Hangman2.Players.Common;
    using System.Collections.Generic;

    public interface IPlayesImporter
    {
        IList<IPlayer> ImportPlayers(string name);
    }
}
