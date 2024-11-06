using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGame;

public class Projectile
{
    public Vector2 position;
    public Vector2 size;
    public float speed = 5;
    private SpriteBatch _spriteBatch;
    private GraphicsDevice _graphicsDevice;
    private Texture2D _texture;
    private Vector2 _velocity;
    private Tank _parent;
    public int _damage { get; private set; }

    public Projectile(Vector2 position, float speed, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Vector2 velocity, int damage, Tank parent)
    {
        _parent = parent;
        _damage = damage;
        size = new Vector2(25, 10);
        this.position = position;
        this.speed = speed;
        _spriteBatch = spriteBatch;
        _graphicsDevice = graphicsDevice;
        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData<Color>(new Color[] { Color.White });
        this._velocity = velocity;

    }
    
    public void Update(GameTime gameTime)
    {
        position = position + _velocity * speed;
        if (CheckForCollision()) Destroy();
    }

    private bool CheckForCollision()
    {
        foreach (Tank tank in Game1.Instance._tanks)
        { 
            if(tank.Equals(_parent)) continue;
            Rectangle tankRect = new Rectangle((int) tank.position.X, (int) tank.position.Y, (int) tank.size.X, (int) tank.size.Y);
            Rectangle projectileRect = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            if (tankRect.Intersects(projectileRect))
            {
                tank.Damage(_damage);
                return true;
            }
        }

        return false;
    }

    private void Destroy()
    {
        _parent._requestedToDelete.Add(this);
    }
    
    public void Draw(GameTime gameTime)
    {
    _spriteBatch.Begin();
    var rectangle = new Rectangle(0, 0, (int) size.X, (int) size.Y);
    _spriteBatch.Draw(_texture, position, rectangle, Color.White);
    _spriteBatch.End();
    
    }
    
    
    
}