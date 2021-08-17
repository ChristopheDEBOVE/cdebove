using System.IO;
using System.Linq;
using FluentAssertions;
using MyHumbleWebSite.DomainModel;
using Xunit;

namespace MyHumbleWebSiteTest
{
    public class SnakeTest
    {
        [Trait("A Snake", "must")]
        [Fact(DisplayName = "Have_a_position_initialy")]
        public void Have_a_position_initialy()
        {
            Snake sut = new(Direction.North, 0, 0);

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

        [Trait("A Snake", "must")]
        [Fact(DisplayName = "Have_just_an_head_initialy")]
        public void Have_just_an_head_initialy()
        {
            Snake sut = GetSnake("North");

            sut.GetParts().Count().Should().Be(1);
        }

        [Theory]
        [InlineData("North", 0, -40)]
        [InlineData("South", 0, 40)]
        [InlineData("East", 40, 0)]
        [InlineData("West", -40, 0)]
        public void Move_forward_the_direction_is_looking(string direction, int expectedX, int expectedY)
        {
            Snake sut = GetSnake(direction);

            sut.MoveOn();

            HeadOf(sut).X.Should().Be(expectedX);
            HeadOf(sut).Y.Should().Be(expectedY);
        }
        
        private Snake GetSnake(string direction)
        {
            return direction switch
            {
                "North" => new Snake(Direction.North, 0, 0),
                "South" => new Snake(Direction.South, 0, 0),
                "East" =>  new Snake(Direction.East, 0, 0),
                "West" =>  new Snake(Direction.West, 0, 0),
                _ => throw new InvalidDataException()
            };
        }
    }
}