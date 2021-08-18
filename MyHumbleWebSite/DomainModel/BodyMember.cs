namespace MyHumbleWebSite.DomainModel
{
    public class BodyMember : IDisplayable
    {
        public int Size { get; } = 40;
        public string Color { get; private set; }
        public Position Position { get; private set; }


        public Shape Shape { get; private set; }

        public BodyMember(Position position, Direction direction)
        {
            Direction = direction;
            Shape = Shape.SnakeBody;
            Position = position;
            Color = "#5c2d91";
        }

        public Direction Direction { get; private set; }

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
            return new(Position.Behind(b.Position, b.Size, b.Direction), b.Direction);
        }


        public void Roll()
        {
            Position = Position.InFront(Position, Size, Direction);
        }

        public BodyMember Clone()
        {
            return new(Position, Direction);
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        public void Necrose()
        {
            Color = "#FF8000";
        }
    }
}