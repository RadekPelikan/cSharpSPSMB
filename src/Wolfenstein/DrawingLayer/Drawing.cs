using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DrawingLayer;

public class Drawing : IDrawing
{
    private GameServiceContainer _services;

    public Drawing(GameServiceContainer services)
    {
        _services = services;

        GraphicsDevice graphicsDevice = services.GetService<GraphicsDevice>();
    }

    public void DrawLine(Vector2 pos1, Vector2 pos2, Color color)
    {
        throw new NotImplementedException();
    }

    public void DrawCircle(Vector2 pos, float radius, Color color)
    {
        throw new NotImplementedException();
    }

    public void DrawRectangle(Rectangle rect, Color color)
    {
        throw new NotImplementedException();
    }

    public void DrawImage(string path, Vector2 pos, Color color)
    {
        throw new NotImplementedException();
    }
}