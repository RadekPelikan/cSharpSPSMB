using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGames.Abstract;
using TestGames.Constants;
using TestGames.Enums;
using TestGames.Extensions;

namespace TestGames.Components;

public abstract class Entity : GameObject
{
    public Vector2 Pos { get; set; }
    public Vector2 Velocity { get; set; } = Vector2.Zero;
    public EntityState State { get; set; } = EntityState.Falling;

    protected Sprite Sprite;
    
    private ISpriteSheet _spriteSheet;

    public Entity(GameServiceContainer services) : base(services)
    {
    }
    
    protected override void Initialize()
    {
        base.Initialize();
        
        _spriteSheet ??= Services.GetServiceOrThrow<ISpriteSheet>();
        Sprite ??= new Sprite(Services, SpritePos.Player);
    }

    public override void Draw()
    {
        Sprite.Draw();
    }
}