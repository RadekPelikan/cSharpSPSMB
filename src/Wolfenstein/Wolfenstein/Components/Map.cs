using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Wolfenstein.interfaces;

namespace Wolfenstein;

public class Map : GameObject, IMap
{
    public Map(GameServiceContainer services) : base(services)
    {
        WallSegments = new List<IWallSegment>();

        // top
        WallSegments.Add(new WallSegment(
            services,
            new Vector2(100, 100),
            new Vector2(200, 100),
            Color.White));

        // right
        WallSegments.Add(new WallSegment(
            services,
            new Vector2(200, 100),
            new Vector2(200, 200),
            Color.White));

        // bottom
        WallSegments.Add(new WallSegment(
            services,
            new Vector2(200, 200),
            new Vector2(100, 200),
            Color.White));

        // left
        WallSegments.Add(new WallSegment(
            services,
            new Vector2(100, 200),
            new Vector2(100, 100),
            Color.White));
    }

    public List<IWallSegment> WallSegments { get; }
    public IPlayer Player { get; }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        foreach (var wallSegment in WallSegments) wallSegment.Draw();
    }
}