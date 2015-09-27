namespace HQC.Project.Hangman2._1.Importers.Common
{
    using HQC.Project.Hangman2._1.Players.Common;
    using System.Collections.Generic;

    public interface IImporter
    {
        IList<IPlayer> Import();
    }
}
