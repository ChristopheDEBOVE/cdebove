using System;

namespace MyHumbleWebSite.DomainModel
{
    public class Apple : IDisplayable
    {
        public Apple(int x, int y) 
        {
            Shape = Shape.GetRandomEnemiesShape();
            X = x;
            Y = y; 
        }

        public int Size { get; } = AppleSize;
        private readonly static int AppleSize = 40;
        public string Color { get; } = "#FF0000";
        public int X { get; }
        public int Y { get; }
        public Shape Shape { get; }

        public static Apple GetRandomlyLocatedDependingOn(int width,int height)
        {
            (int x, int y) = (new Random().Next(AppleSize, width - AppleSize),
                new Random().Next(AppleSize, height - AppleSize));
            return new Apple(x,y);
        }
    }
}