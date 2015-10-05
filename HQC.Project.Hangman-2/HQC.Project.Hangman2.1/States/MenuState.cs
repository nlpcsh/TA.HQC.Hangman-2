// <copyright file="MenuState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class MenuState : State
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="game">???</param>
        public override void Play(GameEngine game)
        {
            while (true)
            {
                Console.Clear();
                game.Logger.PrintMenu();

                string commandToExecute = Console.ReadLine().Trim().ToLower();

                if (Globals.MenuCommandTypes.ContainsKey(commandToExecute))
                {
                    var command = game.CommandFactory.GetCommand(commandToExecute, game, Globals.MenuCommandTypes);
                    command.Execute();
                }
                else
                {
                    game.Logger.PrintMessage("Wrong command!");
                }
            }
        }
    }
}