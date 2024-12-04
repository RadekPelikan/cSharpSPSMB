using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    public List<Tank> _tanks = new List<Tank>();
    public List<Tank> _requestedToDelete = new List<Tank>();
    public static Game1 Instance;

    public Game1()
    {
        Instance = this;
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
        _texture = new Texture2D(GraphicsDevice, 1, 1);
        _texture.SetData<Color>(new Color[] { Color.White });
        _tanks.Add(new Tank(new Vector2(100,100),2,_spriteBatch,GraphicsDevice,Color.Green, 50));
        var controls = new Dictionary<Keys, Keys>()
        {
            {
                Keys.W, Keys.Up
            },
            {
                Keys.S, Keys.Down
            },
            {
                Keys.A, Keys.Left
            },
            {
                Keys.D, Keys.Right
            },
            {
                Keys.Space, Keys.RightControl
            }
        };
        
        _tanks.Add(new Tank(new Vector2(200,200),2,_spriteBatch,GraphicsDevice,Color.Red, 50, controls));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        foreach (var tank in _requestedToDelete)
        {
            _tanks.Remove(tank);
        }
        _requestedToDelete.Clear();
        foreach (var tank in _tanks)
        {
            tank.Update(gameTime);
        }
        
        
        
      
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        foreach (var tank in _tanks)
        { 
            tank.Draw(gameTime);
        }
       
        base.Draw(gameTime);
    }
}