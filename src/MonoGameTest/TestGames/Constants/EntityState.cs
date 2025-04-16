using System;

namespace TestGames.Components;

[Flags]
public enum EntityState
{
    Falling = 1 << 0,
    Moving = 1 << 1,
}