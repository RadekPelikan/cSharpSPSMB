using System;
using Microsoft.Xna.Framework;
using Wolfenstein.interfaces;

namespace Wolfenstein.Components;

public class Player : GameObject, IPlayer
{
    public Player(GameServiceContainer services) : base(services)
    {
    }

    public Vector2 Pos { get; }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        throw new NotImplementedException();
    }
}