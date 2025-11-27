using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameSPSMB;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont font1;
    private Vector2 fontPos;

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
        font1 = Content.Load<SpriteFont>("BaseFont");
        Console.WriteLine(font1.Characters.Count);
        foreach (var font1Character in font1.Characters)
        {
            Console.WriteLine(font1Character);
        }
        Viewport viewport = _graphics.GraphicsDevice.Viewport;

        // TODO: Load your game content here            
        fontPos = new Vector2(viewport.Width / 2, viewport.Height / 2);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        // Draw Hello World
        string output = "AA";


        // Find the center of the string
        Vector2 FontOrigin = font1.MeasureString(output) / 2;
        // Draw the string
        _spriteBatch.DrawString(font1, output, fontPos, Color.LightGreen,
            0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}