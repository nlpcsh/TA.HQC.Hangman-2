namespace HQC.Project.Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using HQC.Project.Hangman.GameScoreBoard;
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2._1.Commands.Common;
    using HQC.Project.Hangman2._1.Common;
    using HQC.Project.Hangman2._1.GameStates;
    using HQC.Project.Hangman2._1.Players.Common;

    public class GameEngine
    {
        public GameEngine(ILogger logger)
        {
            this.Execute = new CommandManager();
            this.WordSelect = new WordSelectorFromFile("../../Words/words.txt");
            this.Scores = new ScoreBoard();
            this.State = new PlayerInitialization();
            this.WordGuess = new Player();
            this.Logger = logger;
            this.CommandFactory = new CommandFactory();
        }

        public GameState State { get; set; }

        public WordSelectorFromFile WordSelect { get; set; }

        public IPlayer WordGuess { get; set; }

        public CommandManager Execute { get; set; }

        public ScoreBoard Scores { get; set; }

        public ILogger Logger { get; private set; }

        public CommandFactory CommandFactory { get; private set; }

        internal void NewGame()
        {
            this.State.Play(this);
        }
    }
}
