namespace HQC.Project.Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using HQC.Project.Hangman2._1.Common;
    using HQC.Project.Hangman2._1.GameStates;
    using HQC.Project.Hangman.Interfaces;

    public class GameEngine
    {
        public GameEngine(ILogger logger)
        {
            this.Execute = new CommandManager();
            this.WordSelect = new WordSelectorFromFile("../../Words/words.txt");
            this.Scores = new ScoreBoard();
            this.State = new InitializeGameState();
            this.WordGuess = new WordGuesser();
            this.Logger = logger;
        }

        public GameState State { get; set; }

        public WordSelectorFromFile WordSelect { get; set; }

        public WordGuesser WordGuess { get; set; }

        public CommandManager Execute { get; set; }

        public ScoreBoard Scores { get; set; }

        public ILogger Logger { get; private set; }

        internal void NewGame()
        {
            this.State.Play(this);
        }
    }
}
