# Top Down Tanky

Cílem projektu je vytvořit hru za pomocí C# .NET a knihovny [monogame](https://monogame.net/) inspirovanou podle hry [Tank Trouble](https://tanktrouble.com/)

Je dovoleno použít jakékoliv assety (obrázky, audio)

Příklad použití monogame: https://github.com/MonoGame/MonoGame.Samples

## 1. část - 23.10.2024

- Vykreslování objektu, který bude znázorňovat tank
- Možnost pohybu tanku pomocí `WASD`

## 2. část - 30.10.2024

- Ošetřování hranic obrazovky, aby tank nemohl jet mimo obrazovku
- Střílení podle směru myši

## 3. část - 6.11.2024

- Na místo pohybu `A` `D` doleva doprava, tank se bude otáčet kolem své osy pomocí těchto kláves
- Jednoduché AI pro nepřátelský tank
- Možnost útočit na jiný tank

## Hodnocení

Každá část je ohodnocena 30 body.

- Splněné zadání: 90 bodů
- Bonusové body: 30 bodů

Každá část má určený termín na odevzdání. Pokud žák neodevzdá část do stanoveného termínu, tak neobdrží body za danou část.

Každá odevzdaná část musí obsahovat požadavky i z předchozích částí

Bonusová část se bude hodnotit až po **splnění 3. části zadání**

> ### Příklad:
> 
> Když žák odevzdá 1. a 3. část v termínu dostane 60 bodů za splněné zadání. Tudíž žák neobdrží body za 2. část, ale musí mít stále splněnou druhou část zadání. 

## Inpirace pro bonusové body

- custom sprites (obrázky)
- Audio
- Kolize s jinými tanky
- Stěny
- Efekty
    - např. trail za tankem když jezdí
    - výbuch zničeného nepřítelského tanku
- Lokální multiplayer


## Vytvoření projektu s monogame

Stáhněte si template s monogame [dotnet-templating](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)

`dotnet new install "MonoGame.Templates.CSharp"`

Vytvořte Solution (Řešení) s použitím monogame templatu. Využijte tempate **MonoGame Windows Desktop Application**

Ve Visual Studiu při vytváření nového řešení zvolíte to stejné na místo nové konzolové aplikace.

![obrazek](https://github.com/user-attachments/assets/f8f4d69b-639a-4305-ae41-d77c5430da74)

Ve visual studiu

![Tutorial](https://github.com/user-attachments/assets/233e48d8-8f2e-4e74-aea0-6b1b59a2502a)

### Jak vykreslit čtvrerec

```csharp
public class Tank : DrawableGameComponent
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
        // int width = GraphicsDevice.PresentationParameters.Bounds.Width;
        // int height = GraphicsDevice.PresentationParameters.Bounds.Height;
        _texture = new Texture2D(GraphicsDevice, 1, 1);
        _texture.SetData<Color>(new Color[] { Color.White });
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // TODO: Add your update logic here
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        var rectangle = new Rectangle(100, 100, 100, 100);
        var position = new Vector2(rectangle.Left, rectangle.Top);
        _spriteBatch.Draw(_texture, position, rectangle, Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
```
