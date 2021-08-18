using System;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using MyHumbleWebSite.DomainModel;

namespace MyHumbleWebSite.Infrastructure
{
    public static class BallDrawingExtension
    {
        public static async Task DrawImageFor(this IDisplayable element, Canvas2DContext context,
            ElementReference imageRef)
        {
            await context.DrawImageAsync(imageRef, element.Position.X - element.Size / 2,
                element.Position.Y - element.Size / 2, element.Size,
                element.Size);
        }


        public static async Task DrawOn(this IDisplayable element, Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(element.Position.X, element.Position.Y, element.Size / 2, 0, Math.PI * 2);
            await context.SetFillStyleAsync(element.Color);
            await context.FillAsync();
            await context.ClosePathAsync();
        }
    }
}