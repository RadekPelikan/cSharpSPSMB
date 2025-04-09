﻿using DrawingLayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Wolfenstein;

public class WolfensteinGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameServiceContainer _services;
    private Drawing _drawing;
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
        _drawing = new Drawing(_services);

        var texture = new Texture2D(GraphicsDevice, 1, 1);y
        texture.SetData(new[] { Color.White });

        _services.AddService(texture);
        _services.AddService<IDrawing>(_drawing);

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
        // TODO: Add your drawing code here
        _drawing.DrawLine(Vector2.Zero, Vector2.One * 1000f, 10, Color.White);

        base.Draw(gameTime);
    }
}