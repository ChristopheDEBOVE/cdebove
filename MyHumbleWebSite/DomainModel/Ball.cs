namespace MyHumbleWebSite.DomainModel
{
    public abstract class Ball
    {
        public static readonly int Size = 20;

        protected Ball(int x, int y, string color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public string Color { get; set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        
        
    }
}