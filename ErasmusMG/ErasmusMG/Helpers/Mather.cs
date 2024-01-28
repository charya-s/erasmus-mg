

using Microsoft.Xna.Framework;

namespace ErasmusMG.Helpers;
public static class Mather
{

    // Return distance between the centers of two rectangles.
    public static float DistanceBetweenRects(Rectangle a, Rectangle b)
    {
        Vector2 aCenter = new(a.X + a.Width / 2, a.Y + a.Height / 2);
        Vector2 bCenter = new(b.X + b.Width / 2, b.Y + b.Height / 2);
        return Vector2.Distance(aCenter, bCenter);
    }
}
