using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Wolfenstein.interfaces;

namespace Wolfenstein.Components;

public class Player : GameObject, IPlayer
{
    private readonly List<IRay> _rays = new();
    private readonly GameServiceContainer _services;

    public Player(GameServiceContainer services) : base(services)
    {
        _services = services;
    }

    public Vector2 Pos { get; private set; }

    public override void Update()
    {
        foreach (var ray in _rays) ray.Update();

        Pos = Mouse.GetState().ToVector2();
        GenerateRays(100);
    }

    public override void Draw()
    {
        foreach (var ray in _rays) ray.Draw();
    }

    private void GenerateRays(int count)
    {
        _rays.Clear();
        for (double angle = 0; angle < Math.PI * 2; angle += Math.PI * 2 / count)
            _rays.Add(new Ray(_services, Pos, (float)angle));
    }
}