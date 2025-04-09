using Microsoft.Xna.Framework;

namespace Wolfenstein.interfaces;
/// <summary>
/// THIS IS INTERFACE FOR WALL SEGMENT
/// </summary>
public interface IWallSegment : IGameObject
{
    Vector2 Pos1 { get; }
    Vector2 Pos2 { get; }
    Color Color { get; }
}