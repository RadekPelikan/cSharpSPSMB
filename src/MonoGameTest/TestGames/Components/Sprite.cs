using Microsoft.Xna.Framework;
using TestGames.Abstract;
using TestGames.Extensions;

namespace TestGames.Components;

public class Sprite : GameObject
{
    public Vector2 Pos { get; set; }
    
    private readonly Vector2 _sheetPos;
    
    private ISpriteSheet _spriteSheet;

    public Sprite(GameServiceContainer services, Vector2 sheetPos) : base(services)
    {
        _sheetPos = sheetPos;
    }

    protected override void Initialize()
    {
        base.Initialize();


        _spriteSheet ??= Services.GetServiceOrThrow<ISpriteSheet>();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        _spriteSheet.Update(gameTime);
    }

    public override void Draw()
    {
        _spriteSheet.DrawSprite(Pos, _sheetPos);
    }
}