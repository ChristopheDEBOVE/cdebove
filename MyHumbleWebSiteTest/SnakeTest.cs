using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using MyHumbleWebSite.DomainModel;
using Xunit;

namespace MyHumbleWebSiteTest
{
    public class SnakeTest
    {
        private string _something = "";

        [Trait("A Snake","must")]
        [Fact(DisplayName = "Have_a_position_initialy")]
        public void Have_a_position_initialy()
        {
            Snake sut = new (Direction.North, 0, 0);
            
            HeadOf(sut).X.Should().Be(0);
            HeadOf(sut).Y.Should().Be(0);
        }

        private static Ball HeadOf(Snake sut)
        {
            return sut.GetParts().First();
        }
        private static Ball BodyOf(Snake sut)
        {
            return sut.GetParts().Skip(1).First();
        }

        [Trait("A Snake","must")]
        [Fact(DisplayName = "Have_just_an_head_initialy")]
        public void Have_just_an_head_initialy()
        {
            Snake sut = GetSnake("North");
            
            sut.GetParts().Count().Should().Be(1);
        }

        [Theory]
        [InlineData("North",0,-1)]
        [InlineData("South",0,1)]
        [InlineData("East",1,0)]
        [InlineData("West",-1,0)]
        public void Move_forward_the_direction_is_looking(string direction, int expectedX,int expectedY)
        {
            Snake sut = GetSnake(direction);
            
            sut.MoveOn();
            
            HeadOf(sut).X.Should().Be(expectedX);
            HeadOf(sut).Y.Should().Be(expectedY);
        }
        
        [Trait("A Snake when move on an apple","his body must")]
        [Fact(DisplayName = "follow his head")]
        public void Body_Member_mustFollow_the_head()
        {
            Snake sut = GetSnake("North");
            var x = HeadOf(sut).X;
            var y = HeadOf(sut).Y;
            BodyOf(sut).X.Should().Be(x);
            BodyOf(sut).Y.Should().Be(y);
        }
        
        
        private Snake GetSnake(string direction)
        {
            switch (direction)
            {
                case "North": return new Snake(Direction.North, 0, 0);
                case "South": return new Snake(Direction.South, 0, 0);
                case "East" : return new Snake(Direction.East, 0, 0);
                case "West" : return new Snake(Direction.West, 0, 0);
            }

            throw new InvalidDataException();
        }
    }
}