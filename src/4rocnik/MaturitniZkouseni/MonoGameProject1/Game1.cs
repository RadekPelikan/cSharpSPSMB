using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameProject1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    // private Vector2 _position = Vector2.One * 100;
    private Vector2 _position = new Vector2(100, 200);
    private SpriteFont _font;
    private Texture2D _pacman;
    
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
        _texture.SetData<Color>([Color.White]);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("Font");
        _pacman = Content.Load<Texture2D>("pacman");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        const int speed = 5;
        // TODO: Add your update logic here
        var state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.W))
        {
            _position.Y -= speed;
        }
        if (state.IsKeyDown(Keys.S))
        {
            _position.Y += speed;
        }
        if (state.IsKeyDown(Keys.A))
        {
            _position.X -= speed;
        }
        if (state.IsKeyDown(Keys.D))
        {
            _position.X += speed;
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(_pacman, new Rectangle((int)_position.X, (int)_position.Y, 100, 100), Color.White);
        _spriteBatch.DrawString(_font, $"X: {_position.X} | Y: {_position.Y}", Vector2.One* 10, Color.White);
        
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}