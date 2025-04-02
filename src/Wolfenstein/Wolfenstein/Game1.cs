using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Wolfenstein.Components;
using Wolfenstein.Domain;

namespace Wolfenstein;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _texture = new Texture2D(GraphicsDevice, 1, 1);
        
        base.Initialize();
        // After load
        Components.Add(new MapRenderer2D(this, GraphicsDevice, _spriteBatch, Map.Factory.CreateBoundsMap(3, 3)));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        // _spriteBatch.Begin();
        //
        // _texture.SetData<Color>(new Color[] { Color.White });
        // _spriteBatch.Draw(_texture, new Vector2(0, 0), new Rectangle(0, 0, 100, 100), Color.White);
        //
        // _spriteBatch.End();

        base.Draw(gameTime);
    }
}
