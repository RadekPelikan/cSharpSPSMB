using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wolfenstein.Domain;

namespace Wolfenstein.Components;

public class MapRenderer2D : DrawableGameComponent
{
    public uint CellSizePx { get; set; } = 100;
    public uint BorderWidthPx { get; set; } = 5;
    public Map Map { get; private set; }
    
    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    private readonly Vector2 _position;
    private readonly Texture2D _texture;

    public MapRenderer2D(Game game, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Vector2 position, Map map) : base(game)
    {
        Map = map;
        _graphicsDevice = graphicsDevice;
        _spriteBatch = spriteBatch;
        _position = position;

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
                position += _position;

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
        {
            var linePosition = position - new Vector2(borderWidthPx, 0);
            linePosition.X += rectangle.Width;
            _spriteBatch.Draw(
                _texture,
                linePosition,
                verticalLine,
                Color.Black
            );
        }

        // Bottom line
        {
            var linePosition = position - new Vector2(0, borderWidthPx);
            linePosition.Y += rectangle.Height;
            _spriteBatch.Draw(
                _texture,
                linePosition,
                horizontalLine,
                Color.Black
            );
        }
        
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