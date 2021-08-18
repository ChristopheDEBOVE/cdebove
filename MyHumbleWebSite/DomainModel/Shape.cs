using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace MyHumbleWebSite.DomainModel
{
    public class Shape : ValueObject
    {
        public static readonly Shape Enemy1 = new("Enemy1");
        public static readonly Shape Enemy2 = new("Enemy2");
        public static readonly Shape Enemy3 = new("Enemy3");
        public static readonly Shape Trolling = new("TrollFace");
        public static readonly Shape SnakeHead = new("SnakeHead");
        public static readonly Shape SnakeBody = new("Body");


        private readonly string _value;

        private Shape(string value)
        {
            _value = value;
        }

        public static Shape GetRandomEnemiesShape()
        {
            // todo : remove this implicit dependency
            return EnemiesShapes[new Random().Next(EnemiesShapes.Length)];
        }

        private static readonly Shape[] EnemiesShapes = {Enemy1, Enemy2, Enemy3};


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }
}