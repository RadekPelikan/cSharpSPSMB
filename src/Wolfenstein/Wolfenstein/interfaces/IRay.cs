using Microsoft.Xna.Framework;

namespace Wolfenstein.interfaces;

public interface IRay : IGameObject
{
    Vector2 Pos { get; }
    int Angle { get; }
}