namespace HQC.Project.Hangman2._1.GameStates
{
    using System;

    using HQC.Project.Hangman;
    using HQC.Project.Hangman2._1.Common;
    using HQC.Project.Hangman2._1.Commands;

    public class PlayGameState : GameState
    {
        public override void Play(GameEngine game)
        {
            while (game.WordGuess.HiddenWord.Contains("_"))
            {
                string commandToExecute = game.Execute.ReadInput();

                if (commandToExecute.Length == 1)
                {
                    char supposedChar = commandToExecute[0];
                    game.WordGuess.InitializationAfterTheGuess(supposedChar);

                }
                 else if (commandToExecute.Equals("help"))
                 {
                     var command = new HelpCommand(game);
                     command.Execute();
                 }
                 else if (commandToExecute.Equals("top"))
                 {
                     var command = new TopCommand(game);
                     command.Execute();
                 }
                 else if (commandToExecute.Equals("restart"))
                 {
                     var command = new RestartCommand(game);
                     command.Execute();
                 }
                 else if (commandToExecute.Equals("exit"))
                 {
                     var command = new ExitCommand(game);
                     command.Execute();
                 }
                 else if (commandToExecute.Equals("option"))
                 {
                     var command = new OptionCommand(game);
                     command.Execute();
                 }
                else
                {
                    Printer.PrintWrongMessage("Wrong input, please try again!");
                }

                ConsoleHelper.ClearConsoleInRange(Globals.LeftPositionCommandInput, Globals.LeftPositionCommandInput + commandToExecute.Length,
                    Globals.TopPositionCommandInput);
                ConsoleHelper.ClearConsoleInRange(Console.WindowWidth / 2 + 1, Console.WindowWidth - 1, Globals.TopPositionCommandInput + 2);

                if (game.WordGuess.Lives == 0)
                {
                    break;
                }
            }

            game.State = new EndGameState();
            game.State.Play(game);
        }
    }
}
