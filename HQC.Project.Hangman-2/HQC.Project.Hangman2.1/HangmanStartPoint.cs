// <copyright file="Hangman.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.Players;
    using HQC.Project.Hangman.UI;
    using HQC.Project.Hangman2.Commands.Common;
    using HQC.Project.Hangman2.GameStates;

    /// <summary>
    /// Start point to the game
    /// </summary>
    public class HangmanStartPoint
    {
        private static void Main(string[] args)
        {
            var state = new MenuState();
            var logger = new ConsoleLogger();
            var wordSelector = new WordSelectorFromFile("../../Words/Random.txt");
            var scores = ScoreBoard.Instance;
            var player = new Player();
            var commandCreator = new CommandFactory();

            var newGame = new HangmanGame(logger, state, wordSelector, scores, player, commandCreator);
            newGame.StartGame();
        }
    }
}