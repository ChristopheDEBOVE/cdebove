using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace MyHumbleWebSite.DomainModel
{
    public class Apple : Ball
    {
        private readonly Shape _shape;

        public Shape Shape => _shape;

        public Apple(int x, int y) : base(x, y,  "#FF0000")
        {
            _shape = Shape.GetRandomEnemiesShape();
        }
    }

    public class Shape : ValueObject
    {
        public static readonly Shape A = new Shape("A");
        public static readonly Shape B = new Shape("B");
        public static readonly Shape C = new Shape("C");
        public static readonly Shape Trolling = new Shape("TrollFace");
        public static readonly Shape SnakeHead = new Shape("SnakeHead");
        public static readonly Shape SnakeBody = new Shape("Body");
        
        private static readonly Shape[] Shapes = {A, B, C};

        public static Shape GetRandomEnemiesShape()
        {
            return Shapes[new Random().Next(Shapes.Length)];
        }
        private readonly string _value;

        private Shape(string value)
        {
            _value = value;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}