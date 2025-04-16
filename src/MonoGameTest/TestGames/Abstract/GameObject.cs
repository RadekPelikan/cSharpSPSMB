using Microsoft.Xna.Framework;

namespace TestGames.Abstract;

public abstract class GameObject : IGameObject
{
    public float Scale { get; protected set; } = 1;
    
    protected readonly GameServiceContainer Services;
    private bool Initialized = false;

    public GameObject(GameServiceContainer services)
    {
        Services = services;
    }
    

    /// <summary>
    /// Called on the first Update method call
    /// </summary>
    protected virtual void Initialize()
    {
        Initialized = true;
    }

    public virtual void Update(GameTime gameTime)
    {
        if (!Initialized)
            Initialize();
    }

    public abstract void Draw();
}