using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace MyHumbleWebSite.DomainModel
{
    public class Shape : ValueObject
    {
        public static readonly Shape A = new("A");
        public static readonly Shape B = new("B");
        public static readonly Shape C = new("C");
        public static readonly Shape Trolling = new("TrollFace");
        public static readonly Shape SnakeHead = new("SnakeHead");
        public static readonly Shape SnakeBody = new("Body");

        private static readonly Shape[] Shapes = {A, B, C};

        private readonly string _value;

        private Shape(string value)
        {
            _value = value;
        }

        public static Shape GetRandomEnemiesShape()
        {
            return Shapes[new Random().Next(Shapes.Length)];
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}