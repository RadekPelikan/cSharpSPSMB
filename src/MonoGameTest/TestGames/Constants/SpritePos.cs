using Microsoft.Xna.Framework;

namespace TestGames.Enums;

public static class SpritePos
{
    public static readonly Vector2 Player = new(0,0);
    public static readonly Vector2 TileLeftTop = new(0,1);
    public static readonly Vector2 TileMidTop = new(1,1);
    public static readonly Vector2 TileRightTop = new(2,1);
    public static readonly Vector2 TileLeftCenter = new(0,2);
    public static readonly Vector2 TileMidCenter = new(1,2);
    public static readonly Vector2 TileRightCenter = new(2,2);
    public static readonly Vector2 TileLeftBottom = new(0,3);
    public static readonly Vector2 TileMidBottom = new(1,3);
    public static readonly Vector2 TileRightBottom = new(2,3);
}