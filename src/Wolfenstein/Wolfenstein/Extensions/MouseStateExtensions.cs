using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Wolfenstein;

public static class MouseStateExtensions
{
    public static Vector2 ToVector2(this MouseState mouseState) =>
        new Vector2(mouseState.X, mouseState.Y);
}