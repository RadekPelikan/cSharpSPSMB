using DrawingLayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Wolfenstein.interfaces;

namespace Wolfenstein;

public class WolfensteinGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameServiceContainer _services;
    private Drawing _drawing;
    private Map _map;
    private SpriteBatch _spriteBatch;

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
        _drawing = new Drawing(_services);
        _map = new Map(_services);

        var texture = new Texture2D(GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.White });

        _services.AddService(_graphics);
        _services.AddService(_spriteBatch);

        _services.AddService(texture);
        _services.AddService<IDrawing>(_drawing);

        // components
        _services.AddService<IMap>(_map);

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
        var center = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
        var cursorPos = Mouse.GetState().ToVector2();
        _drawing.DrawLine(center, cursorPos, 10, Color.White);

        base.Draw(gameTime);
    }
}