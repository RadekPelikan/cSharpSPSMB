using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGames.Components;
using TestGames.Enums;

namespace TestGames;

public class JumperGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameServiceContainer _services;
    private LevelMap _levelMap;
    private SpriteSheet _spriteSheet;

    public JumperGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _services = new GameServiceContainer();
        _levelMap = new LevelMap(_services);
        _spriteSheet = new SpriteSheet(_services,@"img/spritesheet");
        
        _services.AddService(_levelMap);
        _services.AddService<ISpriteSheet>(_spriteSheet);
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _services.AddService(Content);
        _services.AddService(GraphicsDevice);
        _services.AddService(_spriteBatch);
        
        

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _levelMap.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _levelMap.Draw();
        base.Draw(gameTime);
    }
}