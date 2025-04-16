using System;
using DrawingLayer;
using Microsoft.Xna.Framework;
using Wolfenstein.interfaces;

namespace Wolfenstein.Components;

public class CollisionPoint : GameObject, ICollisionPoint
{
    private readonly IDrawing _drawing;

    public CollisionPoint(GameServiceContainer services, IRay ray, IWallSegment wallSegment) : base(services)
    {
        Ray = ray;
        WallSegment = wallSegment;
        CalculateCollision();

        _drawing = services.GetService<IDrawing>();
    }

    public IWallSegment WallSegment { get; }
    public IRay Ray { get; }
    public Vector2? Position { get; private set; }

    public override void Draw()
    {
        var size = 10;
        if (Position is not null)
            _drawing.DrawRectangle(new Rectangle
            {
                X = (int)Position.Value.X - size / 2,
                Y = (int)Position.Value.Y - size / 2,
                Width = size,
                Height = size
            }, Color.Lime);
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }


    private void CalculateCollision()
    {
        var x1 = WallSegment.Pos1.X;
        var y1 = WallSegment.Pos1.Y;

        var x2 = WallSegment.Pos2.X;
        var y2 = WallSegment.Pos2.Y;

        var x3 = Ray.Pos.X;
        var y3 = Ray.Pos.Y;

        var x4 = Ray.Pos.X + 1;
        var y4 = Ray.Pos.Y + 1;

        var den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
        if (den == 0)
            return;

        var t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
        var u = ((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;
        if (t > 0 && t < 1 && u > 0)
            Position = new Vector2
            {
                X = x1 + t * (x2 - x1),
                Y = y1 + t * (y2 - y1)
            };
    }
}