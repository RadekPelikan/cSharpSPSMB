using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameProject1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Vector2 vector = new Vector2(0, 0);
    private Texture2D texture;
    private SpriteFont font;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        texture = new Texture2D(GraphicsDevice, 50, 50);
        font = Content.Load<SpriteFont>("File");
        
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        Console.WriteLine(gameTime.ElapsedGameTime.Milliseconds);

        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            vector.Y += 1;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            vector.Y -= 1;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            vector.X -= 1;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            vector.X += 1;
        }
        
        Console.WriteLine(vector);

        // Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(texture, vector, Color.White);
        _spriteBatch.DrawString(font,"text", new Vector2(10, 10), Color.Black);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}