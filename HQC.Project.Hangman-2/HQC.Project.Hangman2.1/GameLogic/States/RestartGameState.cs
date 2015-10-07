// <copyright file="RestartGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using System;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.GameLogic.States;
    using HQC.Project.Hangman.GameLogic.States.Common;
    using HQC.Project.Hangman.Common;
    using System.Threading;

    /// <summary>
    /// Start new game if player still want to play or redirect to menu. 
    /// </summary>
    public class RestartGameState : State
    {
        /// <summary>
        /// Start new game if player still want to play or redirect to menu. 
        /// </summary>
        /// <param name="game">Instance of <see cref="HangmanGame"/> class.</param>
        public override void Play(HangmanGame game)
        {
            Console.Clear();
            game.Logger.PrintGameTitle();

            Console.Write(Messages.PlayAgainMessage);
            char playAgainYesNo = Console.ReadKey().KeyChar;

            Console.WriteLine();

            if (playAgainYesNo == 'y')
            {
                game.State = new ChooseCategoryState();
                game.State.Play(game);
            }
            else if(playAgainYesNo=='n')
            {
                HangmanStartPoint.Main();
            }
            else
            {
                Console.WriteLine(Messages.WrongCommand);
                Thread.Sleep(500);
                this.Play(game);
            }
        }
    }
}
