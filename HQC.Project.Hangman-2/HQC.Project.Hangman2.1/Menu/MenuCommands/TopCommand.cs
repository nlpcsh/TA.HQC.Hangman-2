// <copyright file="TopCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.Commands
{
    using System;
    using System.Collections.Generic;
    using HQC.Project.Hangman.Common;
    using HQC.Project.Hangman.GameScoreBoard;
    using HQC.Project.Hangman.Menu.MenuCommands;
    using HQC.Project.Hangman.UI.Common;    

    /// <summary>
    /// Show top 5 players
    /// </summary>
    public class TopCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopCommand"/> class.
        /// </summary>
        /// <param name="logger">???</param>
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
            var topPlayers = ScoreBoard.Instance.ScoreBoardTable.TopPlayers;
            var topPlayersToList = new List<string>();

            topPlayersToList.Add(Messages.BestScores);
            for (int i = 0; i < topPlayers.Count; i++)
            {
                if (topPlayers[i] != null && topPlayers[i].Name != Globals.NoPlayer)
                {
                    topPlayersToList.Add(string.Format("{0}. {1} ---> {2}", i + 1, topPlayers[i].Name, topPlayers[i].Score));
                }
                else
                {
                    if (i == 0)
                    {
                        topPlayersToList.Add("No Scores");
                    }

                    break;
                }
            }

            topPlayersToList.Add(Messages.PressAnyKeyMessage);
            this.Logger.Print(topPlayersToList);
            Console.ReadKey();
        }
    }
}
