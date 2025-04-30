using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGames.Abstract;
using TestGames.Constants;
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
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 2, 0, 0, 1, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
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


        int mapWidth = _map.GetLength(1); // Columns (X)
        int mapHeight = _map.GetLength(0); // Rows (Y)
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

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _player.Update(gameTime);

        ApplyPlayerVelocityWithCollision();
        
        CheckPlayerOutOfBounds();
    }

    private void ApplyPlayerVelocityWithCollision()
    {
        Vector2 velocity = _player.Velocity;
        Vector2 size = Vector2.One * _spriteSheet.SpriteRenderSize;
        Vector2 tileSize = size;
        int mapWidth = _map.GetLength(1);
        int mapHeight = _map.GetLength(0);

        // Start with the current player position
        Vector2 pos = _player.Pos;
        bool isTouchingGround = false;

        // --- Horizontal ---
        if (velocity.X != 0)
        {
            pos.X += velocity.X; // Move player horizontally

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (_map[y, x] != 2) continue;

                    Vector2 tilePos = new Vector2(x, y) * tileSize;

                    if (IsColliding(pos, size, tilePos, tileSize))
                    {
                        ResolveCollision(ref pos, size, tilePos, tileSize, Axis.X);
                        velocity.X = 0; // Stop horizontal velocity after collision
                    }
                }
            }
        }

        // --- Vertical ---
        if (velocity.Y != 0)
        {
            pos.Y += velocity.Y; // Move player vertically

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (_map[y, x] != 2) continue;

                    Vector2 tilePos = new Vector2(x, y) * tileSize;

                    if (IsColliding(pos, size, tilePos, tileSize))
                    {
                        ResolveCollision(ref pos, size, tilePos, tileSize, Axis.Y);
                        if (velocity.Y >
                            0) // If the player was falling (positive velocity), stop vertical movement and mark as touching the ground
                        {
                            isTouchingGround = true;
                            velocity.Y = 0; // Stop downward velocity on collision with ground
                            _player.State &= ~EntityState.Falling; // Clear falling state
                        }
                        else if (velocity.Y < 0) // If the player was moving upwards (jumping), stop upwards movement
                        {
                            velocity.Y = 0; // Stop upward velocity
                        }
                    }
                }
            }
        }

        // Apply final corrected position and velocity
        _player.Pos = pos;
        _player.Velocity = velocity;

        // If the player is touching the ground and not jumping, ensure they can jump again
        if (isTouchingGround)
        {
            Console.WriteLine("NOT FALLING");
            _player.State &= ~EntityState.Falling; // Ensure they are not in the falling state if grounded
        }
        else if (!_player.State.HasFlag(EntityState.Falling)) // If not touching the ground and not already falling
        {
            _player.State |= EntityState.Falling; // Set falling state
        }
    }
    

    private bool IsColliding(Vector2 aPos, Vector2 aSize, Vector2 bPos, Vector2 bSize)
    {
        return aPos.X < bPos.X + bSize.X &&
               aPos.X + aSize.X > bPos.X &&
               aPos.Y < bPos.Y + bSize.Y &&
               aPos.Y + aSize.Y > bPos.Y;
    }

    private void ResolveCollision(ref Vector2 playerPos, Vector2 playerSize, Vector2 tilePos, Vector2 tileSize,
        Axis axis)
    {
        float px = playerPos.X;
        float py = playerPos.Y;

        float tx = tilePos.X;
        float ty = tilePos.Y;

        float overlapX = MathF.Min(px + playerSize.X, tx + tileSize.X) - MathF.Max(px, tx);
        float overlapY = MathF.Min(py + playerSize.Y, ty + tileSize.Y) - MathF.Max(py, ty);

        if (overlapX <= 0 || overlapY <= 0)
            return;

        switch (axis)
        {
            case Axis.X:
                if (px < tx)
                    playerPos.X -= overlapX;
                else
                    playerPos.X += overlapX;
                break;

            case Axis.Y:
                if (py < ty) // Player is landing on the tile (touching from above)
                {
                    _player.State &= ~EntityState.Falling; // Player stops falling
                    playerPos.Y -= overlapY; // Correct position
                }
                else
                {
                    _player.State &= ~EntityState.Falling; // Player stops falling
                    playerPos.Y += overlapY;
                }

                break;
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


        // _player.State |= EntityState.Falling;
        if (_player.Pos.X < 0)
            _player.Pos = _player.Pos with { X = 0 };
        if (_player.Pos.X + _spriteSheet.SpriteRenderSize > windowWidth)
            _player.Pos = _player.Pos with { X = windowWidth - _spriteSheet.SpriteRenderSize };
        if (_player.Pos.Y < 0)
        {
            _player.Velocity = _player.Velocity with { Y = 0 };
            _player.Pos = _player.Pos with { Y = 0 };
        }
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

        int mapWidth = _map.GetLength(1); // Columns (X)
        int mapHeight = _map.GetLength(0); // Rows (Y)
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
        int mapWidth = _map.GetLength(1); // Columns (X)
        int mapHeight = _map.GetLength(0); // Rows (Y)

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