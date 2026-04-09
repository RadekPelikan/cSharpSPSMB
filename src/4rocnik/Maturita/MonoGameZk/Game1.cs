using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Color = Microsoft.Xna.Framework.Color;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGameZk;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private static GraphicsDevice _device;
    Vector2 vector = new Vector2(0, 0);
    Texture2D texture = new Texture2D(_device, 50, 50);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
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
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        { 
            vector.Y += 1;
        } else if (Keyboard.GetState().IsKeyDown(Keys.S))
        { 
            vector.Y -= 1;
        } else if (Keyboard.GetState().IsKeyDown(Keys.A))
        { 
            vector.X -= 1;
        } else if (Keyboard.GetState().IsKeyDown(Keys.D))
        { 
            vector.X += 1;
        }
        
        Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        
        _spriteBatch.Draw(texture, vector, Color.White);
        //_spriteBatch.DrawString(Font, "text", new Vector2(10, 10), Color.Black); -- vykresleni textu
        
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}