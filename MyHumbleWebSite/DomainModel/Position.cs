using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using MyHumbleWebSite.Infrastructure;

namespace MyHumbleWebSite.DomainModel
{
    public class Position : ValueObject
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static readonly Position Null = new (0, 0);


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
 

        public double DistanceTo(Position position)
        {
            var (distX, distY) = (this.X - position.X, this.Y - position.Y);
            return Math.Sqrt(distX * distX + distY * distY);
        }
        
        public static Position Behind(Position reference, int distance, Direction Direction)
        {
            if (Direction == Direction.North) return new Position(reference.X, reference.Y + distance);
            if (Direction == Direction.South) return new Position(reference.X, reference.Y - distance);
            if (Direction == Direction.West) return new Position(reference.X + distance, reference.Y);
            if (Direction == Direction.East) return new Position(reference.X- distance, reference.Y);
            throw new ArgumentException($"This direction is not handled {Direction}");
        }
        
        public static Position InFront(Position reference, int distance, Direction Direction)
        {
            if (Direction == Direction.North) return new Position(reference.X, reference.Y - distance);
            if (Direction == Direction.South) return new Position(reference.X, reference.Y + distance);
            if (Direction == Direction.West) return new Position(reference.X - distance, reference.Y);
            if (Direction == Direction.East) return new Position(reference.X+ distance, reference.Y);
            throw new ArgumentException($"This direction is not handled {Direction}");
        }

        public static Position CenterOf(Rectangular map)=> new(map.Width / 2, map.Height / 2);

        public static Position RandomlyLocatedOn(int offset, Rectangular rectangular)
        {
            return new (new Random().Next(offset, rectangular.Width - offset),
                new Random().Next(offset, rectangular.Height - offset));
        }
    }
}