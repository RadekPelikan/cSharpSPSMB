using Microsoft.Xna.Framework;

namespace TestGames.Abstract;

public interface IGameObject
{
    float Scale { get; }
    
    void Update(GameTime gameTime);
    void Draw();
}