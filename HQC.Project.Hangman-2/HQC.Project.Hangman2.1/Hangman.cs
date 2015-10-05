// <copyright file="Hangman.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using HQC.Project.Hangman.UI;

    /// <summary>
    /// ???
    /// </summary>
    public class Hangman
    {
        private static void Main(string[] args)
        {
            var newGame = new GameEngine(new ConsoleLogger());
            newGame.NewGame();
        }
    }
}