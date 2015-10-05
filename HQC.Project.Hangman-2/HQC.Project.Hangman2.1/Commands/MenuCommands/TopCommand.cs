// <copyright file="TopCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.Commands.MenuCommands;

    /// <summary>
    /// Show top 5 players
    /// </summary>
    public class TopCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public TopCommand(ILogger logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Show top 5 players
        /// </summary>
        public override void Execute()
        {
            ScoreBoard.Instance.LoadTopPlayers(Globals.BestScoresPath);
            this.Logger.PrintBestScores(ScoreBoard.Instance.ScoreBoardTable.TopPlayers);
        }
    }
}
