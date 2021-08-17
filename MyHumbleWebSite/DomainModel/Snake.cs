using System.Collections.Generic;
using System.Linq;

namespace MyHumbleWebSite.DomainModel
{
    public class Snake
    {
        public Snake(Direction direction, int x, int y)
        {
            Head = BodyMember.New(x, y, direction);
            body.Add(Head);
        }

        private bool _isAlive = true;

        private void Dead()
        {
            _isAlive = false;
            foreach (var ball in body) ball.Color = "#FF0000";
        }

        private readonly List<BodyMember> body = new();
        private readonly BodyMember Head;

        private void Grow()
        {
            body.Add(BodyMember.NewBodyMemberFollowing(body.Last()));
        }

        public IEnumerable<BodyMember> GetParts()
        {
            return body;
        }


        public void LookToThe(Direction direction)
        {
            if (body.Count() > 1 && Head.Direction.IsOposite(direction))
            {
                Dead();
                return;
            }

            Head.SetDirection(direction);
        }

        public bool CollideWithItSelf()
        {
            return body.Skip(1).Any(a => a.X == Head.X && a.Y == Head.Y);
        }

        public void MoveOn()
        {
            if (!_isAlive)
                return;

            for (var i = body.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    body[i].Roll();
                    continue;
                }
                
                body[i] = body[i - 1].Clone();
            }

            if (CollideWithItSelf()) Dead();
        }

        public bool TryEat(Apple apple)
        {
            if (apple != null && apple.X == Head.X && apple.Y == Head.Y)
            {
                Grow();
                return true;
            }

            return false;
        }
    }
}