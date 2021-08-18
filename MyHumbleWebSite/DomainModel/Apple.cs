using MyHumbleWebSite.Infrastructure;

namespace MyHumbleWebSite.DomainModel
{
    public class Apple : IDisplayable
    {
        public Apple(Position Position)
        {
            Shape = Shape.GetRandomEnemiesShape();
            this.Position = Position;
        }

        public int Size { get; } = AppleSize;
        private static readonly int AppleSize = 40;
        public string Color { get; } = "#FF0000";
        public Position Position { get; }
        public Shape Shape { get; }

        public static Apple GetRandomlyLocatedOn(Rectangular rectangular)
        {
            return new(Position.RandomlyLocatedOn(AppleSize, rectangular));
        }
    }
}