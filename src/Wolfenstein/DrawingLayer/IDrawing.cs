using Microsoft.Xna.Framework;

namespace DrawingLayer;

public interface IDrawing
{
    /// <summary>
    ///     Draw a line WOW
    /// </summary>
    /// <param name="pos1">Vector2 starting position</param>
    /// <param name="pos2">Vector2 ending position</param>
    /// <param name="color">Color color of the line</param>
    public void DrawLine(Vector2 pos1, Vector2 pos2, float width, Color color);

    public void DrawCircle(Vector2 pos, float radius, Color color);

    public void DrawRectangle(Rectangle rect, Color color);

    public void DrawImage(string path, Vector2 pos, Color color);
}