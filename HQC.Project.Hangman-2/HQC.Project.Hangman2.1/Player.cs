namespace HQC.Project.Hangman2._1
{
    using System;

    public class Player
    {
        private string name;
        private int mistakes;

        public Player()
        {
        }

        public Player(string playerName, int mistakes)
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
