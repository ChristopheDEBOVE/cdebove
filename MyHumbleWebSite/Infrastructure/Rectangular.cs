namespace MyHumbleWebSite.Infrastructure
{
    
    public class Rectangular
    {
        public int Height { get; }
        public int Width { get; }
        
        public Rectangular(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public static Rectangular NullAreaRectangular() => new Rectangular(0, 0);

        public static Rectangular Resize(Rectangular map, double d)=>new((int) (map.Height * d),(int) (map.Width * d));
    }
}