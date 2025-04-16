using Microsoft.Xna.Framework;
using TestGames.Abstract;

namespace TestGames.Components;

public interface ISpriteSheet : IGameObject
{
    uint SpriteSize { get; }
    uint SpriteRenderSize { get; }
    void DrawSprite(Vector2 pos, uint x, uint y);
    void DrawSprite(Vector2 pos, Vector2 sheetPos);
}