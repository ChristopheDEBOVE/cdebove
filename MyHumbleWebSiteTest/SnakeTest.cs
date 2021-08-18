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
            Snake sut = new(Direction.North, Position.Null);

            HeadOf(sut).Position.Should().Be(Position.Null);
        }

        private static IDisplayable HeadOf(Snake sut)
        {
            return sut.ElementsToShow().First();
        }

 
        [Trait("A Snake", "must")]
        [Fact(DisplayName = "Have_just_an_head_and_one_part_initialy")]
        public void Have_just_an_head_initialy()
        {
            Snake sut = GetSnake("North");

            sut.ElementsToShow().Count().Should().Be(2);
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

            HeadOf(sut).Position.Should().Be(new Position(expectedX,expectedY));

        }

        private Snake GetSnake(string direction)
        {
            return direction switch
            {
                "North" => new Snake(Direction.North, Position.Null),
                "South" => new Snake(Direction.South,Position.Null),
                "East" => new Snake(Direction.East,Position.Null),
                "West" => new Snake(Direction.West,Position.Null),
                _ => throw new InvalidDataException()
            };
        }
    }
}