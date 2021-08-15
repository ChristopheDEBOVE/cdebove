using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace christophedebove
{
    public class Direction : ValueObject
    {
        private readonly string _value;

        private Direction(string value)
        {
            _value = value;
        }

        public static Direction North = new("North");
        public static Direction East = new("East");
        public static Direction South = new("South");
        public static Direction West = new("West");
        public override string ToString() => _value;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}