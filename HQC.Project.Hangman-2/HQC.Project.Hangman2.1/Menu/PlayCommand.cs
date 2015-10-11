// <copyright file="PlayCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Commands
{
    using Common;
    using Contracts;
    using GameLogic;
    using GameLogic.States;
    using GameScoreBoard;
    using Importers;
    using Menu.MenuCommands;
    using Players;

    /// <summary>
    /// Play command starts the game.
    /// </summary>
    public class PlayCommand : MenuCommand
    {
       /// <summary>
        /// Initializes a new instance of the <see cref="PlayCommand"/> class.
       /// </summary>
        /// <param name="ui">IUI that prints massages.</param>
        public PlayCommand(IUI ui)
            : base(ui)
        {
        }

        /// <summary>
        /// Executes play command and starts the game.
        /// </summary>
        public override void Execute()
        {
            var wordSelector = new WordSelectorFromFile("../../Words/Random.txt");
            var scores = ScoreBoard.Instance;
            var player = new Player();
            var commandFactory = new CommandFactory();

            var game = new HangmanGame(this.UI, new PlayerInitializationState(), wordSelector, scores, player, commandFactory);
            game.StartGame();
        }
    }
}
