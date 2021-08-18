using System;

namespace MyHumbleWebSite.DomainModel
{
    public static class IDisplayableExtension
    {
        public static bool CollidesWith(this IDisplayable element1, IDisplayable element2)
        {
            var (distX, distY) = (element1.X - element2.X, element1.Y - element2.Y);
            var distance = Math.Sqrt(distX * distX + distY * distY);
            return !(distance > element1.Size);
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