namespace HQC.Project.Hangman2._1.Interfaces
{
    using System.Collections.Generic;

    public interface IImporter
    {
        IList<IPlayer> Import();
    }
}
