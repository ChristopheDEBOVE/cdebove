using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHumbleWebSite.DomainModel
{
    public class Snake
    {
        public Snake(Direction direction, int x, int y)
        {
            body.Add(new BodyMember(x, y, direction));
        }

        private bool _isAlive = true;

        private void Dead()
        {
            _isAlive = false;
            foreach (var ball in body) ball.Color = "#FF8000";
        }

        private readonly List<BodyMember> body = new();
        private BodyMember Head => body.First();
        private bool HasABody => body.Count > 1;
        private bool IsLookingToTheOpositeWay(Direction direction) => Head.Direction.IsOposite(direction);
        public IEnumerable<BodyMember> GetParts()=>body;

        private void Grow()
        {
            body.Add(BodyMember.NewBodyMemberFollowing(body.Last()));
        }
        
        public void LookToThe(Direction direction)
        {
            if (HasABody && IsLookingToTheOpositeWay(direction))
            {
                Dead();
                return;
            }

            Head.SetDirection(direction);
        }

        private bool CollideWithItSelf()
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
            if (apple == null || !Head.CollidesWith(apple)) return false;
               
            Grow();
            return true;
        }


    }
}