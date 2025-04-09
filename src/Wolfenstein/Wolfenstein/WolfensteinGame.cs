using DrawingLayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Wolfenstein;

public class WolfensteinGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameServiceContainer _services;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;

    public WolfensteinGame()
    {
        _services = new GameServiceContainer();
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
        _texture = new Texture2D(GraphicsDevice, 1, 1);
        _texture.SetData(new[] { Color.White });
        var drawing = new Drawing(_services);

        _services.AddService<IDrawing>(drawing);
        _services.AddService(_graphics);
        _services.AddService(_spriteBatch);
        _services.AddService(_texture);

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
        
        var drawing = _services.GetService<IDrawing>();
        
        drawing.DrawRectangle(new Rectangle(0, 0, 100, 100), Color.White);

        base.Draw(gameTime);
    }
}