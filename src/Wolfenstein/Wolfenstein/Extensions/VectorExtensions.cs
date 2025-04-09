using System;
using Microsoft.Xna.Framework;

namespace Wolfenstein;

public static class Vector2Extensions
{
    public static Point ToPoint(this Vector2 vector)
    {
        return new Point((int)vector.X, (int)vector.Y);
    }

    public static double GetAngle(this Vector2 vector)
    {
        return Math.Atan2(vector.Y, vector.X);
    }

    public static float GetDistance(this Vector2 vector, Vector2 target)
    {
        return Vector2.Distance(vector, target);
    }

    public static float GetMagnitude(this Vector2 vector)
    {
        return GetDistance(Vector2.Zero, vector);
    }

    public static float GetDotProduct(this Vector2 vector, Vector2 other)
    {
        return Vector2.Dot(vector, other);
    }
}