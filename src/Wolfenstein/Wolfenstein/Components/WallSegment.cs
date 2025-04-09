using DrawingLayer;
using Microsoft.Xna.Framework;
using Wolfenstein.interfaces;

namespace Wolfenstein;

public class WallSegment : GameObject, IWallSegment
{
    private readonly IDrawing _drawing;

    public WallSegment(GameServiceContainer services, Vector2 pos1, Vector2 pos2, Color color) : base(services)
    {
        Pos1 = pos1;
        Pos2 = pos2;
        Color = color;
        _drawing = services.GetService<IDrawing>();
    }

    public Vector2 Pos1 { get; }
    public Vector2 Pos2 { get; }
    public Color Color { get; }


    public override void Update()
    {
    }

    public override void Draw()
    {
        _drawing.DrawLine(Pos1, Pos2, 10, Color);
    }
}