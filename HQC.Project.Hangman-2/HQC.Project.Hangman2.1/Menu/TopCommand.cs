// <copyright file="TopCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Commands
{
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using GameScoreBoard;
    using Menu.MenuCommands;

    /// <summary>
    /// Show top 5 players.
    /// </summary>
    public class TopCommand : MenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopCommand"/> class.
        /// </summary>
        /// <param name="ui">IUI that prints massages.</param>
        public TopCommand(IUI ui)
            : base(ui)
        {
        }

        /// <summary>
        /// Show top 5 players.
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
            this.UI.Print(topPlayersToList);
            this.UI.ReadKey();
        }
    }
}
