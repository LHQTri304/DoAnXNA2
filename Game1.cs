using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2;
public class Game1 : Game
{
    private GraphicsDeviceManager Graphics;
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false; // Ẩn con trỏ chuột
    }

    protected override void Initialize()
    {
        // Thiết lập kích thước của cửa sổ
        Graphics.IsFullScreen = false;
        Graphics.PreferredBackBufferWidth = MainRes.ScreenWidth;
        Graphics.PreferredBackBufferHeight = MainRes.ScreenHeight;
        Graphics.ApplyChanges();

        // Tạo RenderTarget với kích thước cố định
        _renderTarget = new RenderTarget2D(GraphicsDevice, MainRes.ScreenWidth, MainRes.ScreenHeight);

        // Khởi tạo tất cả data thường dùng cần thiết
        MainRes.Initialize();        

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); //Tạo sprite batch        
        Textures.LoadAll(Content); // Load tất cả các texture trong file texture2D.cs
        Soundtrack.LoadAll(Content); // Load tất cả các soundtrack trong file soundtrack.cs
        ReadyMadeBtn.InitAndLoad(); // Load tất cả các Button thường dùng
        MainRes.Font = SpriteFonts.LoadSpriteFonts(Content); // Load tất cả các font hiện có (1 cái duy nhất)

        //tránh lỗi null khi run
        MainRes.PlayerShip.ReloadTexture();
        MainRes.Cursor.ReloadTexture();

        // GameState (Screen)
        MainRes.GSM = new GameStateManager();
        MainRes.CurrentState = new MainMenu();

        // UI
        MainRes.GameHUD = [
            new NextLevelMilestoneHUD(),
            new GameScoreHUD(),
            new PlayerHeathHUD()
        ];
    }

    protected override void Update(GameTime _gameTime)
    {
        MainRes.CurrentState.Update(_gameTime);
        base.Update(_gameTime);
    }

    protected override void Draw(GameTime _gameTime)
    {
        //Dùng RenderTarget vẽ màn hình theo kích thước tùy ý
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.Indigo);

        //Nội dung màn hình
        _spriteBatch.Begin();
        MainRes.CurrentState.Draw(_spriteBatch);
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        DrawScaledScreen(_spriteBatch, _renderTarget);

        base.Draw(_gameTime);
    }

    private void DrawScaledScreen(SpriteBatch spriteBatch, RenderTarget2D renderTarget)
    {
        // Tính toán tỷ lệ để phóng lớn nội dung theo kích thước cửa sổ
        float scaleX = (float)Window.ClientBounds.Width / MainRes.ScreenWidth;
        float scaleY = (float)Window.ClientBounds.Height / MainRes.ScreenHeight;
        float scale = Math.Min(scaleX, scaleY); // Giữ nguyên tỷ lệ khung hình

        // Tính toán vị trí để vẽ nội dung ở giữa cửa sổ
        int scaledWidth = (int)(MainRes.ScreenWidth * scale);
        int scaledHeight = (int)(MainRes.ScreenHeight * scale);

        int offsetX = (Window.ClientBounds.Width - scaledWidth) / 2; // Khoảng trống bên trái và phải
        int offsetY = (Window.ClientBounds.Height - scaledHeight) / 2; // Khoảng trống bên trên và dưới

        // Vẽ nội dung của RenderTarget vào cửa sổ với tỷ lệ đã tính
        spriteBatch.Begin();
        spriteBatch.Draw(renderTarget,
                        new Rectangle(offsetX, offsetY, scaledWidth, scaledHeight),
                        Color.White);
        spriteBatch.End();
    }
}
