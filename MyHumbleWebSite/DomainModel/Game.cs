using System;
using System.Collections.Generic;
using MyHumbleWebSite.Infrastructure;
using static MyHumbleWebSite.DomainModel.Direction;

namespace MyHumbleWebSite.DomainModel
{
    public class NullGame : Game
    {
        public NullGame() : base(0, 0)
        {
        }

        public override IEnumerable<IDisplayable> ElementsToShow()=> ArraySegment<IDisplayable>.Empty;
    }
    public class Game
    {
        public int Score { get; private set; }
        
        private readonly int _mapWidth;
        private readonly int _mapHeight;
        private Snake _snake;
        private Apple _apple;

        public Game(int mapWidth, int mapHeight)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            StartANewGame();
        }

        private void StartANewGame()
        {
            Score = 0;
            _snake = new Snake(North, _mapWidth / 2, _mapHeight / 2);
        }

        private void GenerateApple()
        {
            _apple = Apple.GetRandomlyLocatedDependingOn((int) (_mapWidth * 0.8),(int) (_mapHeight * 0.8));
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