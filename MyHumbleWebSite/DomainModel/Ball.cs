using System;

namespace MyHumbleWebSite.DomainModel
{
    public static class BallExtension
    {
        public static bool CollidesWith(this Ball ball, Ball ball2)
        {
            var (distX, distY) = (ball.X - ball2.X, ball.Y - ball2.Y);
            var distance = Math.Sqrt((distX * distX) + (distY * distY));
            if (distance > Ball.Size) return false;
            return true;
        }
    }
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