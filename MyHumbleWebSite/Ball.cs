namespace christophedebove
{
    public class Ball
    {
        private Direction direction;

        public Ball(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public double Size { get;} = 10;

        public void Roll()
        {
            if (direction == Direction.North) Y--;
            if (direction == Direction.South) Y++;
            if (direction == Direction.West) X--;
            if (direction == Direction.East) X++;
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }
    }
}