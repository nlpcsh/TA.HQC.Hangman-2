using HQC.Project.Hangman;
using HQC.Project.Hangman2.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQC.Project.Hangman2._1
{
    public abstract class GameCommand : Command
    {
        public GameCommand(GameEngine game): base(game)
        {
        }
    }
}
