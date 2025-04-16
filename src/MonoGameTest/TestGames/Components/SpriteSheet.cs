using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestGames.Abstract;
using TestGames.Extensions;

namespace TestGames.Components;

public class SpriteSheet : GameObject, ISpriteSheet
{
    public Texture2D SheetTexture { get; private set; }
    public uint SpriteSize {get; private set;}
    
    public uint SpriteRenderSize => (uint)(SpriteSize * Scale);
    
    private string _sheetName;
    
    private SpriteBatch _spriteBatch;
    private ContentManager _content;

    public SpriteSheet(GameServiceContainer services, string sheetName, uint spriteSize=8) : base(services)
    {
        _sheetName = sheetName;
        SpriteSize = spriteSize;
        
        Scale = 4;
    }
    
    protected override void Initialize()
    {
        base.Initialize();
        
        _content ??= Services.GetServiceOrThrow<ContentManager>();
        SheetTexture ??= _content.Load<Texture2D>(_sheetName);
        _spriteBatch ??= Services.GetServiceOrThrow<SpriteBatch>();
    }
    
    public override void Draw()
    {
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
        
        Vector2 scaleVector = new Vector2(Scale, Scale);

        _spriteBatch.Draw(SheetTexture,
            Vector2.Zero,
            null,
            Color.White,
            0f,
            Vector2.Zero,
            scaleVector,
            SpriteEffects.None,
            0f);
        
        
        _spriteBatch.End();
    }
    
    public void DrawSprite(Vector2 pos, uint x, uint y)
    {
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
    
        // Define the scale vector
        Vector2 scaleVector = new Vector2(Scale, Scale);

        // Calculate the source rectangle for the sprite to be drawn
        Rectangle sourceRectangle = new Rectangle(
            (int)(x * SpriteSize),   // X position of the sprite in the sprite sheet
            (int)(y * SpriteSize),   // Y position of the sprite in the sprite sheet
            (int)SpriteSize,         // Width of the sprite
            (int)SpriteSize          // Height of the sprite
        );

        // Draw the sprite from the sprite sheet with the specified source rectangle
        _spriteBatch.Draw(SheetTexture,
            pos,                    // Position on the screen
            sourceRectangle,        // Source rectangle from the sprite sheet
            Color.White,            // Color of the sprite
            0f,                     // Rotation
            Vector2.Zero,           // Origin for rotation/scaling (top-left corner)
            scaleVector,            // Scale of the sprite
            SpriteEffects.None,     // No sprite flipping
            0f);                    // Layer depth

        _spriteBatch.End();
    }

    public void DrawSprite(Vector2 pos, Vector2 sheetPos) => 
        DrawSprite(pos, (uint) sheetPos.X, (uint) sheetPos.Y);
}