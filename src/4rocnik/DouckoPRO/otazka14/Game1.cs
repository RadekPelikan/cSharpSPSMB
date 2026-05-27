using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace otazka14;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    private SpriteFont _spriteFont;
    private Vector2 _position = Vector2.Zero;

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
        _texture = Content.Load<Texture2D>("obrazek");
        _spriteFont = Content.Load<SpriteFont>("Font");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var state = Keyboard.GetState();
        var speed = 1;
        
        if (state.IsKeyDown(Keys.LeftShift))
            speed = 5;
        
        if (state.IsKeyDown(Keys.W))
            _position.Y -= speed;
        if (state.IsKeyDown(Keys.S))
            _position.Y += speed;
        if (state.IsKeyDown(Keys.A))
            _position.X -= speed;
        if (state.IsKeyDown(Keys.D))
            _position.X += speed;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();


        Color color = Color.White;
        
        //Draw(Texture2D, Vector2, Rectangle?, Color, float, Vector2, float, SpriteEffects, float)
        _spriteBatch.Draw(
            _texture, 
            _position, 
            new Rectangle(0, 0, _texture.Width, _texture.Height), 
            color, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
        _spriteBatch.DrawString(_spriteFont, $"X: {_position.X} | Y: {_position.Y}", Vector2.Zero, Color.White);
        

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}