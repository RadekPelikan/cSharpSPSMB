using Microsoft.Xna.Framework;

namespace DrawingLayer;

public interface IDrawing
{
    public void DrawLine(Vector2 pos1, Vector2 pos2, Color color);

    public void DrawCircle(Vector2 pos, float radius, Color color);

    public void DrawRectangle(Rectangle rect, Color color);

    public void DrawImage(string path, Vector2 pos, Color color);
}