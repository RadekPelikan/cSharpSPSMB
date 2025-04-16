using Microsoft.Xna.Framework;

namespace TestGame;

public abstract class GameObject
{
    protected readonly GameServiceContainer Services;

    public GameObject(GameServiceContainer services)
    {
        Services = services;
    }

    public abstract void Update();

    public abstract void Draw();
}