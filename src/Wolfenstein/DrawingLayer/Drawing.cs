using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DrawingLayer;

public class Drawing : IDrawing
{
    private readonly GameServiceContainer _services;

    public Drawing(GameServiceContainer services)
    {
        _services = services;
    }

    public void DrawLine(Vector2 pos1, Vector2 pos2, float width, Color color)
    {
        var spriteBatch = _services.GetService<SpriteBatch>();
        var texture = _services.GetService<Texture2D>();
        // Calculate the distance between the two points (line length)
        var lineLength = Vector2.Distance(pos1, pos2);

        // Calculate the angle between the two points
        var angle = (float)Math.Atan2(pos2.Y - pos1.Y, pos2.X - pos1.X);

        // Begin drawing with the SpriteBatch
        spriteBatch.Begin();

        // Draw the stretched and rotated texture (line)
        spriteBatch.Draw(
            texture, // Texture to draw
            pos1, // Starting position
            null, // No source rectangle (draw the whole texture)
            color, // Line color
            angle, // Rotation angle
            Vector2.Zero, // Origin of the texture (top-left corner)
            new Vector2(lineLength, width), // Scale to the length and width of the line
            SpriteEffects.None, // No sprite effects (no flipping)
            0 // Layer depth (0 means it's drawn on top)
        );

        // End drawing with the SpriteBatch
        spriteBatch.End();
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