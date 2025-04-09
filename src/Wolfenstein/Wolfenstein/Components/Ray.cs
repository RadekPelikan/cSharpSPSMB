using System;
using System.Collections.Generic;
using DrawingLayer;
using Microsoft.Xna.Framework;
using Wolfenstein.interfaces;

namespace Wolfenstein.Components;

public class Ray : GameObject, IRay
{
    private readonly IDrawing _drawing;
    private List<IWallSegment> _wallSegments;

    public Ray(GameServiceContainer services, Vector2 pos, float angle) : base(services)
    {
        Pos = pos;
        Angle = angle;

        _drawing = services.GetService<IDrawing>();
        _wallSegments = services.GetService<IMap>().WallSegments;
    }

    public Vector2 Pos { get; }
    public float Angle { get; }
    public ICollisionPoint CollisionPoint { get; }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        var pos2 = Vector2.One * 100;
        pos2.Rotate(Angle);
        _drawing.DrawLine(Pos, pos2, 8, Color.White);
    }
}