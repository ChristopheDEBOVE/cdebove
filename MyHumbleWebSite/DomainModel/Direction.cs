using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace MyHumbleWebSite.DomainModel
{
    public static class DirectionHelper
    {
        public static bool IsOposite(this Direction directionA, Direction directionB)
        {
            return directionA == Direction.North && directionB == Direction.South
                   || directionA == Direction.South && directionB == Direction.North
                   || directionA == Direction.East && directionB == Direction.West
                   || directionA == Direction.West && directionB == Direction.East;
        }
    }

    public class Direction : ValueObject
    {
        public static readonly Direction North = new("North");
        public static readonly Direction East = new("East");
        public static readonly Direction South = new("South");
        public static readonly Direction West = new("West");
        private readonly string _value;

        private Direction(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}