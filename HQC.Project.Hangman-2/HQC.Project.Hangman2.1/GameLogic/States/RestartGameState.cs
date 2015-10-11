// <copyright file="RestartGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.GameLogic.States
{
    using Common;
    using Hangman;
    using Hangman.Common;
 
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
            game.UI.Print("Title", "Title");

            game.UI.Print(Messages.PlayAgainMessage, "Message");

            char playAgainYesNo = game.UI.ReadKey();

            if (playAgainYesNo == 'y')
            {
                game.State = new ChooseCategoryState();
                game.State.Play(game);
            }
            else if (playAgainYesNo == 'n')
            {
                HangmanStartPoint.Main();
            }
            else
            {
                game.UI.Print(Messages.WrongCommand, "Message");
                this.Play(game);
            }
        }
    }
}
