using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGames.Abstract;
using TestGames.Enums;
using TestGames.Extensions;

namespace TestGames.Components;

public class LevelMap : GameObject
{
    public Vector2 Pos { get; set; }
    public Vector2 Velocity { get; set; } = Vector2.Zero;

    private readonly PlayerOutOfBoundsBehaviour _outOfBoundsBehavior = PlayerOutOfBoundsBehaviour.Contain;

    private Player _player;

    private ISpriteSheet _spriteSheet;
    private GraphicsDevice _graphicsDevice;

    /// <summary>
    /// numbers indicate tiles
    ///
    /// 0: air
    /// 1: player (fails, if more than one)
    /// 2: ground
    /// </summary>
    private int[,] _map = new[,]
    {
        { 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 2, 2, 0 },
        { 0, 0, 0, 2, 2, 0 },
        { 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2 },
        { 0, 0, 0, 0, 0, 0 },
    };

    public LevelMap(GameServiceContainer services) : base(services)
    {
    }

    protected override void Initialize()
    {
        base.Initialize();

        _graphicsDevice ??= Services.GetServiceOrThrow<GraphicsDevice>();
        _spriteSheet ??= Services.GetServiceOrThrow<ISpriteSheet>();
        _player ??= new Player(Services);


        var mapWidth = _map.GetLength(0);
        var mapHeight = _map.Length / mapWidth;
        bool isPlayer = false;
        for (uint y = 0; y < mapHeight; y++)
        {
            for (uint x = 0; x < mapWidth; x++)
            {
                if (isPlayer is false && _map[y, x] == 1)
                {
                    isPlayer = true;
                    _player.Pos = new Vector2(x, y) * _spriteSheet.SpriteRenderSize;
                }
                else if (isPlayer && _map[y, x] == 1)
                {
                    throw new ArgumentException("Multiple players are not supported");
                }
            }
        }
    }

    public override void Update()
    {
        base.Update();

        _player.Update();

        CheckPlayerOutOfBounds();

        CheckPlayerGroundCollisions();
    }

    private void CheckPlayerGroundCollisions()
    {
        Vector2 playerPos = _player.Pos;
        Vector2 playerSize = Vector2.One * _spriteSheet.SpriteRenderSize; // Change if your player is larger
        Vector2 tileSize = Vector2.One * _spriteSheet.SpriteRenderSize;

        int mapWidth = _map.GetLength(1);
        int mapHeight = _map.GetLength(0);

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                if (_map[y, x] != 2) continue; // Not ground, skip

                Vector2 tilePos = new Vector2(x, y) * _spriteSheet.SpriteRenderSize;

                if (IsColliding(playerPos, playerSize, tilePos, tileSize))
                {
                    Vector2 pos = _player.Pos;

                    ResolveCollision(ref pos, playerSize, tilePos, tileSize);

                    _player.Pos = pos; // <- apply the updated position
                }
            }
        }
    }

    private bool IsColliding(Vector2 aPos, Vector2 aSize, Vector2 bPos, Vector2 bSize)
    {
        return aPos.X < bPos.X + bSize.X &&
               aPos.X + aSize.X > bPos.X &&
               aPos.Y < bPos.Y + bSize.Y &&
               aPos.Y + aSize.Y > bPos.Y;
    }

    private void ResolveCollision(ref Vector2 playerPos, Vector2 playerSize, Vector2 tilePos, Vector2 tileSize)
    {
        float px = playerPos.X;
        float py = playerPos.Y;

        float tx = tilePos.X;
        float ty = tilePos.Y;

        float overlapX = MathF.Min(px + playerSize.X, tx + tileSize.X) - MathF.Max(px, tx);
        float overlapY = MathF.Min(py + playerSize.Y, ty + tileSize.Y) - MathF.Max(py, ty);

        if (overlapX <= 0 || overlapY <= 0)
            return; // No actual overlap, just in case

        // Push out along the axis of least overlap
        if (overlapX < overlapY)
        {
            if (px < tx)
                playerPos.X -= overlapX; // Push left
            else
                playerPos.X += overlapX; // Push right
        }
        else
        {
            if (py < ty)
            {
                _player.State &= ~EntityState.Falling;
                playerPos.Y -= overlapY; // Push up
            }
            else
                playerPos.Y += overlapY; // Push down
        }
    }


    private void CheckPlayerOutOfBounds()
    {
        _ = _outOfBoundsBehavior switch
        {
            PlayerOutOfBoundsBehaviour.Contain => PlayerOutofBoundsContain(),
            PlayerOutOfBoundsBehaviour.Respawn => throw new System.NotImplementedException(
                "PlayerOutOfBoundsBehaviour.Respawn not implemented"),
            _ => throw new System.NotImplementedException()
        };
    }

    private object PlayerOutofBoundsContain()
    {
        int windowWidth = _graphicsDevice.Viewport.Width;
        int windowHeight = _graphicsDevice.Viewport.Height;


        _player.State |= EntityState.Falling;
        if (_player.Pos.X < 0)
            _player.Pos = _player.Pos with { X = 0 };
        if (_player.Pos.X + _spriteSheet.SpriteRenderSize > windowWidth)
            _player.Pos = _player.Pos with { X = windowWidth - _spriteSheet.SpriteRenderSize };
        if (_player.Pos.Y < 0)
            _player.Pos = _player.Pos with { Y = 0 };
        if (_player.Pos.Y + _spriteSheet.SpriteRenderSize > windowHeight)
        {
            _player.State &= ~EntityState.Falling;
            _player.Pos = _player.Pos with { Y = windowHeight - _spriteSheet.SpriteRenderSize };
        }

        return null;
    }

    public override void Draw()
    {
        _player.Draw();

        var mapWidth = _map.GetLength(0);
        var mapHeight = _map.Length / mapWidth;
        for (uint y = 0; y < mapHeight; y++)
        {
            for (uint x = 0; x < mapWidth; x++)
            {
                var sheetPos = GetSheetPosFromMap(x, y);
                if (sheetPos is not null)
                    _spriteSheet.DrawSprite(
                        new Vector2(x, y) * _spriteSheet.SpriteRenderSize,
                        sheetPos.Value);
            }
        }
    }

    private Vector2? GetSheetPosFromMap(uint x, uint y)
        => _map[y, x] switch
        {
            0 => null, // Air
            1 => null, // Player
            2 => GetGround(x, y), // Ground
            _ => throw new System.NotImplementedException($"Sprite for number {_map[y, x]} is not implemented")
        };


    private Vector2 GetGround(uint x, uint y)
    {
        int mapWidth = _map.GetLength(1);
        int mapHeight = _map.Length / mapWidth;

        bool IsGround(int tx, int ty)
        {
            return tx >= 0 && ty >= 0 && tx < mapWidth && ty < mapHeight && _map[ty, tx] == 2;
        }

        // Check neighbors
        bool up = IsGround((int)x, (int)y - 1);
        bool down = IsGround((int)x, (int)y + 1);
        bool left = IsGround((int)x - 1, (int)y);
        bool right = IsGround((int)x + 1, (int)y);

        // Full surrounded
        if (up && down && left && right)
            return SpritePos.TileMidCenter;

        // Bottom edge — show bottom tile
        if (!down && up && left && right)
            return SpritePos.TileMidBottom;
        if (!down && up && left && !right)
            return SpritePos.TileRightBottom;
        if (!down && up && !left && right)
            return SpritePos.TileLeftBottom;

        // Top edge — show top tile
        if (!up && down && left && right)
            return SpritePos.TileMidTop;
        if (!up && down && left && !right)
            return SpritePos.TileRightTop;
        if (!up && down && !left && right)
            return SpritePos.TileLeftTop;

        // Sides
        if (!left && up && down)
            return SpritePos.TileLeftCenter;
        if (!right && up && down)
            return SpritePos.TileRightCenter;

        // One neighbor (lonely edges)
        if (down && !up && !left && !right)
            return SpritePos.TileMidTop;
        if (up && !down && !left && !right)
            return SpritePos.TileMidBottom;
        if (left && !up && !down && !right)
            return SpritePos.TileRightCenter;
        if (right && !up && !down && !left)
            return SpritePos.TileLeftCenter;

        // Fallback
        return SpritePos.TileMidTop;
    }
}