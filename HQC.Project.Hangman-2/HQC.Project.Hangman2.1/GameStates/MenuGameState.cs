namespace HQC.Project.Hangman2.GameStates
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Commands.Common;
    using HQC.Project.Hangman;
    using HQC.Project.Hangman.Common;
   
    public class MenuGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            while (true)
            {
                Console.Clear();
                game.Logger.PrintMenu();

                string commandToExecute = Console.ReadLine().Trim().ToLower();

                if (Globals.CommandTypes.ContainsKey(commandToExecute))
                {
                    var command = game.CommandFactory.GetCommand(commandToExecute, game);
                    Console.Clear();
                    command.Execute();
                    Thread.Sleep(1000);
                }
                else
                {
                    game.Logger.PrintMessage("Wrong command!");
                }

            }
        }
    }
}