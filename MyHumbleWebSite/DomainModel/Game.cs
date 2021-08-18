using System;
using System.Collections.Generic;
using MyHumbleWebSite.Infrastructure;
using static MyHumbleWebSite.DomainModel.Direction;

namespace MyHumbleWebSite.DomainModel
{
    public class NullGame : Game
    {
        public NullGame() : base(Rectangular.NullAreaRectangular())
        {
        }

        public override IEnumerable<IDisplayable> ElementsToShow()=> ArraySegment<IDisplayable>.Empty;
    }
    public class Game
    {
        public int Score { get; private set; }
        
        private readonly Rectangular _map;
        private Snake _snake;
        private Apple _apple;

        public Game(Rectangular map)
        {
            _map = map;
            StartANewGame();
        }

        private void StartANewGame()
        {
            Score = 0;
            _snake = new Snake(North, Position.CenterOf(_map));
        }

        private void GenerateApple()
        {
            _apple = Apple.GetRandomlyLocatedOn(_map);
        }

        public void Tick()
        {
            _snake?.MoveOn();
            if (_snake != null && (_apple == null || _snake.TryEat(_apple)))
            {
                Score++;
                GenerateApple();
            }
        }

        public void KeyStroked(KeyBoard.Key key)
        {
            if (_snake == null) return;

            if (key == KeyBoard.Key.ArrowDown) _snake.LookToThe(South);
            if (key == KeyBoard.Key.ArrowUp) _snake.LookToThe(North);
            if (key == KeyBoard.Key.ArrowLeft) _snake.LookToThe(West);
            if (key == KeyBoard.Key.ArrowRight) _snake.LookToThe(East);
            if (key == KeyBoard.Key.Space) StartANewGame();
        }

        public virtual IEnumerable<IDisplayable> ElementsToShow()
        {
            foreach (var bodyMember in _snake.GetParts()) yield return bodyMember;
            yield return _apple;
        }
    }
}