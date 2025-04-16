using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGames.Enums;

namespace TestGames.Components;

public class Player : Entity
{
    public Player(GameServiceContainer services) : base(services)
    {
    }

    public override void Update()
    {
        base.Update();

        Sprite.Update();
        var keyboardState = Keyboard.GetState();

        var newVelocity = Velocity;

        if (State.HasFlag(EntityState.Falling))
            newVelocity += Vector2.UnitY * GameConfig.GravityAcc;
        
        if (keyboardState.IsKeyDown(Keys.A))
        {
            newVelocity.X = -GameConfig.PlayerSpeed;
            State |= EntityState.Moving;
        }
        if (keyboardState.IsKeyUp(Keys.D) && keyboardState.IsKeyUp(Keys.A) && State.HasFlag(EntityState.Moving))
        {
            newVelocity.X = 0;
            State &= ~EntityState.Moving;
        }
        
        if (keyboardState.IsKeyDown(Keys.D))
        {
            newVelocity.X = GameConfig.PlayerSpeed;
            State |= EntityState.Moving;
        }
        if (keyboardState.IsKeyUp(Keys.A) && keyboardState.IsKeyUp(Keys.D) && State.HasFlag(EntityState.Moving))
        {
            newVelocity.X = 0;
            State &= ~EntityState.Moving;
        }

        if ((keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Space)) &&
            State.HasFlag(EntityState.Falling) is false)
        {
            newVelocity.Y = -GameConfig.PlayerJumpAcc;
            State |= EntityState.Falling;
        }


        Velocity = newVelocity;
        Pos += Velocity;

    }

    public override void Draw()
    {
        Sprite.Pos = Pos;
        base.Draw();
    }
}