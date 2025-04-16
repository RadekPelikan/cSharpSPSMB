using Microsoft.Xna.Framework;

namespace Wolfenstein.interfaces;

/// <summary>
/// </summary>
public interface IPlayer : IGameObject
{
    Vector2 Pos { get; }
}