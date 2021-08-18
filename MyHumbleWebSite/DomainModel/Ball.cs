using System;

namespace MyHumbleWebSite.DomainModel
{
    public static class BallExtension
    {
        public static bool CollidesWith(this IDisplayable ball, IDisplayable ball2)
        {
            var (distX, distY) = (ball.X - ball2.X, ball.Y - ball2.Y);
            var distance = Math.Sqrt(distX * distX + distY * distY);
            return !(distance > ball.Size);
        }
    }

    public interface IDisplayable 
    {
        int Size { get; } 
        string Color { get; }
        int X { get; }
        int Y { get; }
        Shape Shape { get;}
    }
}