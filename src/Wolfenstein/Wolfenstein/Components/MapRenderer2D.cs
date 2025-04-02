using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wolfenstein.Domain;

namespace Wolfenstein.Components;

public class MapRenderer2D : DrawableGameComponent
{
    public uint CellSizePx { get; set; } = 100;
    public uint BorderWidthPx { get; set; } = 20;
    public Map Map { get; private set; }
    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    private readonly Texture2D _texture;

    public MapRenderer2D(Game game, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Map map) : base(game)
    {
        Map = map;
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;

        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData<Color>(new Color[] { Color.White });
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        var cells = Map.Cells;

        var rectangle = new Rectangle()
        {
            Width = (int)CellSizePx,
            Height = (int)CellSizePx,
        };
        for (uint y = 0; y < Map.Height; y++)
        {
            for (uint x = 0; x < Map.Width; x++)
            {
                var position = new Vector2
                {
                    X = x * CellSizePx,
                    Y = y * CellSizePx
                };

                switch (cells[y, x].Type)
                {
                    case CellType.Empty:
                        DrawEmpty(position, rectangle);
                        break;
                    case CellType.Wall:
                        DrawWall(position, rectangle);
                        break;
                    default:
                        throw new NotImplementedException("Unknown cell type");
                }
            }
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }

    private void DrawWall(Vector2 position, Rectangle rectangle)
    {
        var borderWidthPx = (int) BorderWidthPx;
        var horizontalLine = new Rectangle()
        {
            Width = rectangle.Width,
            Height = borderWidthPx,
        };
        var verticalLine = new Rectangle()
        {
            Width = borderWidthPx,
            Height = rectangle.Height,
        };
        _spriteBatch.Draw(_texture, position, rectangle, Color.White);


        // return;
        // Top line
        _spriteBatch.Draw(
            _texture, 
            position, 
            horizontalLine, 
            Color.Black
            );

        // Right line
        _spriteBatch.Draw(
            _texture,
            position with { X = position.X + rectangle.Width },
            verticalLine with { X = -borderWidthPx },
            Color.Black
            );

        // Bottom line
        _spriteBatch.Draw(
            _texture,
            position with { Y = position.Y + rectangle.Height },
            horizontalLine with { Y = -borderWidthPx },
            Color.Black
            );
        
        // Left line
        _spriteBatch.Draw(
            _texture,
            position,
            verticalLine,
            Color.Black
            );
    }

    private void DrawEmpty(Vector2 position, Rectangle rectangle)
    {
        // _texture.SetData<Color>(new Color[] { Color.White });
        // _spriteBatch.Draw(_texture, position, rectangle, Color.White);
    }
}