using System.Collections.Generic;
using MyHumbleWebSite.Infrastructure;

namespace MyHumbleWebSite.DomainModel
{
    public class Game
    {
        private readonly int _width;
        private readonly int _height;
        private Snake Snake { get; set; }
        private Apple Apple { get; set; }
        public int Score { get; private set; }
        private readonly (int X, int Y) InitialPosition;

        public Game(int width, int height)
        {
            _width = width;
            _height = height;
            InitialPosition = (width / 2, height / 2);
            if (Snake == null)
                GenerateSnake();
        }

        private void GenerateSnake()
        {
            Score = 0;
            Snake = new Snake(Direction.North, InitialPosition.X, InitialPosition.Y);
        }

        private void GenerateApple()
        {
            Apple = Apple.GetRandomlyLocatedDependingOn((int) (_width * 0.8),(int) (_height * 0.8));
        }

        public void Tick()
        {
            Snake?.MoveOn();
            if (Snake != null && (Apple == null || Snake.TryEat(Apple)))
            {
                Score++;
                GenerateApple();
            }
        }

        public void KeyStroked(object sender, KeyBoard.OnKeyStrokedArgs args)
        {
            if (Snake == null) return;

            if (args.Key == KeyBoard.Key.ArrowDown) Snake.LookToThe(Direction.South);
            if (args.Key == KeyBoard.Key.ArrowUp) Snake.LookToThe(Direction.North);
            if (args.Key == KeyBoard.Key.ArrowLeft) Snake.LookToThe(Direction.West);
            if (args.Key == KeyBoard.Key.ArrowRight) Snake.LookToThe(Direction.East);
            if (args.Key == KeyBoard.Key.Space) GenerateSnake();
        }

        public IEnumerable<IDisplayable> ElementsToShow()
        {
            foreach (var bodyMember in Snake.GetParts()) yield return bodyMember;
            yield return Apple;
        }
    }
}