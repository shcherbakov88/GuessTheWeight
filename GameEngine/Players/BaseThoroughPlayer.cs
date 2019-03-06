namespace GameEngine.Players
{
    /// <summary>
    /// Represents the base class for the thorough players.
    /// </summary>
    public abstract class BaseThoroughPlayer : Player
    {
        protected int Counter;

        internal override void PrepareForTheNextGame()
        {
            Counter = 0;
            base.PrepareForTheNextGame();
        }

        protected BaseThoroughPlayer(string name) : base(name)
        {   
        }
    }
}