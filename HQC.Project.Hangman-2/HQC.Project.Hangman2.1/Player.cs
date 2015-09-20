namespace HQC.Project.Hangman
{
    using System;

    public class Player
    {
        private const int InitialLives = 7;
        private const int InitialMistakes = 0;

        private string name;
        private int mistakes;

        public Player()
        {
            this.Lives = Player.InitialLives;
            this.Mistakes = Player.InitialMistakes;
        }

        public Player(string playerName, int mistakes)
            : this()
        {
            this.Name = playerName;
            this.Mistakes = mistakes;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Player must have at least one symbol!");
                }

                this.name = value;
            }
        }

        public int Mistakes
        {
            get
            {
                return this.mistakes;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player mistakes cannot be less than 0!");
                }

                this.mistakes = value;
            }
        }

        public int Lives { get; private set; }

        public int Compare(Player otherPlayer)
        {
            if (this.Mistakes <= otherPlayer.Mistakes)
            {
                return -1;
            }
            else
            {
                //// the newer one replaces the older
                return 1;
            }
        }
    }
}
