// <copyright file="Hangman.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.UI;

    /// <summary>
    /// Start point to the game
    /// </summary>
    public class HangmanStartPoint
    {
        private static void Main(string[] args)
        {
            var newGame = new HangmanGame(new ConsoleLogger());
            newGame.StartGame();
        }
    }
}