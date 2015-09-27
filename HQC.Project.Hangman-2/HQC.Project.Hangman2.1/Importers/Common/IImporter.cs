namespace HQC.Project.Hangman2.Importers.Common
{
    using HQC.Project.Hangman2.Players.Common;
    using System.Collections.Generic;

    public interface IImporter
    {
        IList<IPlayer> Import();
    }
}
