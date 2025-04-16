using System;

namespace TestGames.Constants;

[Flags]
public enum EntityState
{
    Falling = 1 << 0,
    Moving = 1 << 1,
    CanJump = 1 << 2,
}