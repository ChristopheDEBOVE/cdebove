namespace MyHumbleWebSite.DomainModel
{
    public static class IDisplayableExtension
    {
        public static bool CollidesWith(this IDisplayable element1, IDisplayable element2)
        {
            return !(element1.Position.DistanceTo(element2.Position) > element1.Size);
        }
    }

    public interface IDisplayable
    {
        int Size { get; }
        string Color { get; }
        Position Position { get; }
        Shape Shape { get; }
    }
}