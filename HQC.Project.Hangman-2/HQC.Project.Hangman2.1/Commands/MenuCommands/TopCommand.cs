// <copyright file="TopCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman2.Commands.Common;

    /// <summary>
    /// Show top 5 players
    /// </summary>
    public class TopCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopCommand"/> class.
        /// </summary>
        /// <param name="currentGame">???</param>
        public TopCommand(HangmanGame currentGame)
            : base(currentGame)
        {
        }

        /// <summary>
        /// ???
        /// </summary>
        public override void Execute()
        {
            this.Game.Scores.LogLine(string.Empty);
            ScoreBoard.Instance.LoadTopPlayers(Globals.BestScoresPath);

            this.Game.Logger.PrintBestScores(ScoreBoard.Instance.ScoreBoardTable.TopPlayers);
        }
    }
}
