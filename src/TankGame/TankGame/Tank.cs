using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
/* --- */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TankGame;

public class Tank
{
    public Vector2 position;
    public Vector2 size;
    public float speed = 5;
    private SpriteBatch _spriteBatch;
    private GraphicsDevice _graphicsDevice;
    private Texture2D _texture;
    private double timer;
    private double fireRate = 2;
    public List<Projectile> _projectiles = new List<Projectile>();
    public List<Projectile> _requestedToDelete = new List<Projectile>();

    private Dictionary<Keys, Keys> _controls = new Dictionary<Keys, Keys>()
    {
        {
            Keys.W, Keys.W
        },
        {
            Keys.S, Keys.S
        },
        {
            Keys.A, Keys.A
        },
        {
            Keys.D, Keys.D
        },
        {
            Keys.Space, Keys.Space
        },


    };

    private int _hp;


    public Tank(Vector2 position, float speed, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color color,
        int hp, Dictionary<Keys, Keys> controls = null)
    {
        _hp = hp;
        size = new Vector2(100, 100);
        this.position = position;
        this.speed = speed;
        _spriteBatch = spriteBatch;
        _graphicsDevice = graphicsDevice;
        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData<Color>(new Color[] { color });
        if (controls != null)
        {
            _controls = controls;
        }
    }

    public void Update(GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        // TODO: Add your update logic here
        Vector2 velocity = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(_controls[Keys.W]))
        {
            velocity.Y = -1;
        }

        if (Keyboard.GetState().IsKeyDown(_controls[Keys.S]))
        {
            velocity.Y = 1;
        }

        if (Keyboard.GetState().IsKeyDown(_controls[Keys.A]))
        {
            velocity.X = -1;
        }

        if (Keyboard.GetState().IsKeyDown(_controls[Keys.D]))
        {
            velocity.X = 1;
        }

        if (Keyboard.GetState().IsKeyDown(_controls[Keys.Space]) && timer > 1 / fireRate)
        {
            _projectiles.Add(new Projectile(position, 3f, _spriteBatch, _graphicsDevice, Vector2.UnitX, 10, this));
            timer = 0;
        }

        velocity *= speed;
        if (velocity.Length() > speed)
            velocity = velocity / velocity.Length() * speed;

        position += velocity;

        for (int i = 0; i < _projectiles.Count; i++)
        {
            var projectile = _projectiles[i];
            _projectiles[i].Update(gameTime);
            if (projectile.position.X < 0 ||
                projectile.position.X > _graphicsDevice.Viewport.Width ||
                projectile.position.Y < 0 ||
                projectile.position.Y > _graphicsDevice.Viewport.Height)
            {
                _projectiles.RemoveAt(i);
            }
        }

    }

    public void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        var rectangle = new Rectangle(100, 100, (int)size.X, (int)size.Y);
        _spriteBatch.Draw(_texture, position, rectangle, Color.White);
        _spriteBatch.End();

        foreach (var projectile in _requestedToDelete)
        {
            _projectiles.Remove(projectile);
        }
        _requestedToDelete.Clear();
        foreach (var projectile in _projectiles)
        {
            projectile.Draw(gameTime);
        }
    }

    public void Damage(int damage)
    {
        _hp -= damage;
        Console.WriteLine("Zbývající hp: " + _hp);
        if (_hp <= 0) Destroy();
    }

    private void Destroy()
    {
        Game1.Instance._requestedToDelete.Add(this);
    }
}
