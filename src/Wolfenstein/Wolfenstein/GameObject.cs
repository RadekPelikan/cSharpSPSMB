using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wolfenstein;

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