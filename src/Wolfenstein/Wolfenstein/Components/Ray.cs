using System;
using System.Collections.Generic;
using DrawingLayer;
using Microsoft.Xna.Framework;
using Wolfenstein.interfaces;

namespace Wolfenstein.Components;

public class Ray : GameObject, IRay
{
    private readonly List<ICollisionPoint> _collisionPoints = new();
    private readonly IDrawing _drawing;

    private readonly GameServiceContainer _services;
    private readonly List<IWallSegment> _wallSegments;

    public Ray(GameServiceContainer services, Vector2 pos, float angle) : base(services)
    {
        Pos = pos;
        Angle = angle;
        _services = services;

        _drawing = services.GetService<IDrawing>();
        _wallSegments = services.GetService<IMap>().WallSegments;
    }

    public Vector2 Pos { get; }
    public float Angle { get; }
    public ICollisionPoint CollisionPoint { get; }

    public override void Update()
    {
        _collisionPoints.Clear();
        foreach (var wallSegment in _wallSegments)
        {
            var collisionPoint = new CollisionPoint(_services, this, wallSegment);
            if (collisionPoint.Position is not null) _collisionPoints.Add(collisionPoint);
        }
    }

    public override void Draw()
    {
        foreach (var collisionPoint in _collisionPoints) collisionPoint.Draw();
        if (_collisionPoints.Count > 0) Console.WriteLine(_collisionPoints.Count);
        var pos2 = Vector2.One * 100;
        pos2.Rotate(Angle);
        _drawing.DrawLine(Pos, Pos + pos2, 2, Color.White);
    }
}