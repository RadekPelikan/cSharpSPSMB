namespace TestGames.Abstract;

public interface IGameObject
{
    float Scale { get; }
    
    void Update();
    void Draw();
}