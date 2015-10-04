namespace HQC.Project.Hangman2.GameStates
{
    using HQC.Project.Hangman;

    public abstract class State
    {
        public abstract void Play(GameEngine game);
    }
}
