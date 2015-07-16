namespace HQC.Project.Hangman_2
{
    using System;
    using HQC.Project.Hangman2;

    public class ScoreBoard
    {
        private static Player[] scoreBoardTable = new Player[Globals.ScoreBoardSize];

        public static void PlacePlayerInScoreBoard(Player player)
        {
            int emptyPosition = GetFirstFreePosition();

            if (scoreBoardTable[emptyPosition] == null || player.Mistakes <= scoreBoardTable[emptyPosition].Mistakes)
            {
                scoreBoardTable[emptyPosition] = player;

                for (int i = emptyPosition; i > 0; i--)
                {
                    Player firstPlayer = scoreBoardTable[i];
                    Player secondPlayer = scoreBoardTable[i - 1];

                    if (firstPlayer.Compare(secondPlayer) < 0)
                    {
                        //// swap
                        scoreBoardTable[i] = secondPlayer;
                        scoreBoardTable[i - 1] = firstPlayer;
                    }
                }
            }
        }

        public static void PrintTopResults()
        {
            Console.WriteLine();
            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (scoreBoardTable[i] != null)
                {
                    Console.WriteLine("{0}. {1} ---> {2}", i + 1, scoreBoardTable[i].Name, scoreBoardTable[i].Mistakes);
                }
            }

            Console.WriteLine();
        }

        private static int GetFirstFreePosition()
        {
            int freePosition = Globals.LastPositionInScoreBoard;

            for (int i = 0; i < Globals.ScoreBoardSize; i++)
            {
                if (scoreBoardTable[i] == null)
                {
                    freePosition = i;
                    break;
                }
            }

            return freePosition;
        }
    }
}
