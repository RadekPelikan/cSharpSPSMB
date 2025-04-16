using Microsoft.Xna.Framework;

namespace Wolfenstein.interfaces;

public interface ICollisionPoint : IGameObject
{
    IWallSegment WallSegment { get; }
    IRay Ray { get; }
    Vector2? Position { get; }
}