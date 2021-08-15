using System;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace christophedebove
{
    public static class BallDrawingExtension
    {
        public static async  Task DrawOn(this Ball ball,Canvas2DContext context)
        {
            await context.ArcAsync(ball.X, ball.Y, ball.Size, 0, Math.PI * 2);
        }
    }
}