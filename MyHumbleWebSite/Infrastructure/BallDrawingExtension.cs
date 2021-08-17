using System;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using MyHumbleWebSite.DomainModel;

namespace MyHumbleWebSite.Infrastructure
{
    public static class BallDrawingExtension
    {
        public static async  Task<Ball> DrawOn(this Ball ball,Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(ball.X, ball.Y, Ball.Size/2, 0, Math.PI * 2);
            await context.SetFillStyleAsync(ball.Color);
            await context.FillAsync();
            await context.ClosePathAsync();
            return ball;
        }
    }
}