using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame.Components;

public class Player : GameObject
{
    private SpriteBatch _spriteBatch;
    
    private readonly GameServiceContainer _services;

    public Player(GameServiceContainer services) : base(services)
    {
        _services = services;
    }

    public override void Update()
    {
        if (_spriteBatch is null)
            _spriteBatch = _services.GetService<SpriteBatch>();
        
        
    }

    public override void Draw()
    {
        throw new System.NotImplementedException();
    }
}