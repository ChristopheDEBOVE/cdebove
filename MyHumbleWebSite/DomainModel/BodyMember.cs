namespace MyHumbleWebSite.DomainModel
{
    public class BodyMember : Ball
    {
        public Direction Direction { get; private set; }
        public BodyMember(int x, int y, Direction direction) : base(x, y, "#800000")
        {
            this.Direction = direction;
        }
        public static BodyMember NewBodyMemberFollowing(BodyMember b)
        {
            if (b.Direction == Direction.North) return new BodyMember(b.X, b.Y + Size * 2, b.Direction);
            if (b.Direction == Direction.South) return new BodyMember(b.X, b.Y - Size * 2, b.Direction);
            if (b.Direction == Direction.West) return new BodyMember(b.X + Size * 2, b.Y, b.Direction);
            if (b.Direction == Direction.East) return new BodyMember(b.X - Size * 2, b.Y, b.Direction);
            return b;
        }
        public void Roll()
        {
            if (Direction == Direction.North) Y-=Size*2;
            if (Direction == Direction.South) Y+=Size*2;
            if (Direction == Direction.West) X-=Size*2;
            if (Direction == Direction.East) X+=Size*2;
        }
        public static BodyMember New(int x, int y, Direction direction)
        {
            return new(x, y, direction);
        }

        public BodyMember Clone() => New(X, Y, Direction);
    
        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }
    }
}