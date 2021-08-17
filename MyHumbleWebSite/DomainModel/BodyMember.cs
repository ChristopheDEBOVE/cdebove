using System.Data;

namespace MyHumbleWebSite.DomainModel
{
    public class BodyMember : Ball
    {
        public Direction Direction { get; private set; }

        public BodyMember(int x, int y, Direction direction) : base(x, y, "#688A08")
        {
            Direction = direction;
        }

        public static BodyMember NewBodyMemberFollowing(BodyMember b)
        {
            if (b.Direction == Direction.North) return new (b.X, b.Y + Size, b.Direction);
            if (b.Direction == Direction.South) return new (b.X, b.Y - Size, b.Direction);
            if (b.Direction == Direction.West) return new (b.X + Size, b.Y, b.Direction);
            if (b.Direction == Direction.East) return new (b.X - Size, b.Y, b.Direction);
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