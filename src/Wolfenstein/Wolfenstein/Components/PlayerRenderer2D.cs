using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wolfenstein.Domain;

namespace Wolfenstein.Components;

public class PlayerRenderer2D : DrawableGameComponent
{
    public Player Player { get; }

    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    private readonly Vector2 _position;
    private readonly Texture2D _texture;

    public PlayerRenderer2D(Game game, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Vector2 position,
        Player player) : base(game)
    {
        Player = player;
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
        _position = position;
        
        _texture = Game.Content.Load<Texture2D>("img/player");
        // _texture.SetData<Color>(new Color[] { Color.White });
    }

    public override void Draw(GameTime gameTime)
    { 
        _spriteBatch.Begin();
        
        _spriteBatch.Draw(_texture, _position , Color.White);
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
