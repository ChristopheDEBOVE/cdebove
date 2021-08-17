namespace MyHumbleWebSite.Infrastructure
{
    public class BrowserDimension
    {
        public BrowserDimension(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; }
        public int Width { get; }
    }
}