using System.Data;

namespace MyHumbleWebSite.DomainModel
{
    public class BodyMember : Ball
    {
        public BodyMember(int x, int y, Direction direction) : base(x, y, "#5c2d91")
        {
            Direction = direction;
        }

        public Direction Direction { get; private set; }
        public Shape Shape { get; private set; } = Shape.SnakeBody;

        public BodyMember SetSnakeHeadFace()
        {
            Shape = Shape.SnakeHead;
            return this;
        }

        public BodyMember SetTrollFace()
        {
            Shape = Shape.Trolling;
            return this;
        }

        public static BodyMember NewBodyMemberFollowing(BodyMember b)
        {
            if (b.Direction == Direction.North) return new BodyMember(b.X, b.Y + Size, b.Direction);
            if (b.Direction == Direction.South) return new BodyMember(b.X, b.Y - Size, b.Direction);
            if (b.Direction == Direction.West) return new BodyMember(b.X + Size, b.Y, b.Direction);
            if (b.Direction == Direction.East) return new BodyMember(b.X - Size, b.Y, b.Direction);
            throw new ConstraintException($"The direction is not handled {b.Direction}");
        }

        public void Roll()
        {
            if (Direction == Direction.North) Y -= Size;
            if (Direction == Direction.South) Y += Size;
            if (Direction == Direction.West) X -= Size;
            if (Direction == Direction.East) X += Size;
        }

        public BodyMember Clone()
        {
            return new(X, Y, Direction);
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }
    }
}