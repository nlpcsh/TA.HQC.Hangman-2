namespace HQC.Project.Hangman2._1.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }

        int Mistakes { get; set; }

        int Lives { get; set; }

        int Compare(IPlayer otherPlayer);
    }
}
