using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQC.Project.Hangman2._1.Importers.Common
{
    public interface IWordsImporter
    {
        string SelectRandomWord();
    }
}
