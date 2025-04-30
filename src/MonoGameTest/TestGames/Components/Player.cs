using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGames.Constants;
using TestGames.Enums;

namespace TestGames.Components;

public class Player : Entity
{
    // protected new EntityState State
    // {
    //     get => _state;
    //     set
    //     {
    //         // if (value.HasFlag(EntityState.Falling))
    //         // {
    //         //     Console.WriteLine("Falling");
    //         //     _state = value | EntityState.CanJump;
    //         // }
    //         _state = value;
    //     }
    // }
    //
    // private EntityState _state;
    private float _jumpCounter;

    public Player(GameServiceContainer services) : base(services)
    {
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        Console.WriteLine(State);
        if (State.HasFlag(EntityState.CanJump))
        {
            _jumpCounter += gameTime.ElapsedGameTime.Milliseconds;
        }

        if (_jumpCounter > GameConfig.PlayerJumpMillisAfter)
        {
            _jumpCounter = 0;
            State &= ~EntityState.CanJump;
        }

        Sprite.Update(gameTime);
        var keyboardState = Keyboard.GetState();

        var newVelocity = Velocity;

        // Check gravity if the player is falling
        if (State.HasFlag(EntityState.Falling))
            newVelocity += Vector2.UnitY * GameConfig.GravityAcc;

        // Horizontal movement (left / right)
        if (keyboardState.IsKeyDown(Keys.A))
        {
            newVelocity.X = -GameConfig.PlayerSpeed;
            State |= EntityState.Moving;
        }
        else if (keyboardState.IsKeyDown(Keys.D))
        {
            newVelocity.X = GameConfig.PlayerSpeed;
            State |= EntityState.Moving;
        }
        else
        {
            newVelocity.X = 0;
            State &= ~EntityState.Moving;
        }
        
        // Jumping logic: only jump if you're not already falling
        if ((keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Space)) &&
            !State.HasFlag(EntityState.CanJump)) // Prevent jumping while falling
        {
            newVelocity.Y = -GameConfig.PlayerJumpAcc;
            State |= EntityState.Falling;  // Set the player to "falling" once they jump
        }

        Velocity = newVelocity;
    }



    public override void Draw()
    {
        Sprite.Pos = Pos;
        base.Draw();
    }
}