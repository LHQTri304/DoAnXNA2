using System;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    int virtualWidth = 540; // Chiều rộng cố định của nội dung game
    int virtualHeight = 960;  // Chiều cao cố định của nội dung game
    RenderTarget2D renderTarget;
    private SpriteBatch _spriteBatch;

    //the sprites
    private PlayerShip _playerShip;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // Thiết lập kích thước của cửa sổ
        _graphics.PreferredBackBufferWidth = virtualWidth;
        _graphics.PreferredBackBufferHeight = virtualHeight;
        _graphics.ApplyChanges();

        // Cho phép thay đổi kích thước cửa sổ
        Window.AllowUserResizing = true;

        // Nếu muốn fullscreen, thêm dòng này
        _graphics.IsFullScreen = true;

        // Tạo RenderTarget với kích thước cố định
        renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);

        // Lấy vị trí giữa khung hình
        float windowWidth = _graphics.PreferredBackBufferWidth;
        float windowHeight = _graphics.PreferredBackBufferHeight;
        //Vector2 centerPosition = new Vector2(windowWidth / 2, windowHeight / 2);
        Vector2 beginPosition = new Vector2(100, 100);

        // Tạo các sprites
        _playerShip = new PlayerShip(null, beginPosition, 1000f);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load tất cả các texture trong file texture2D.cs
        Textures.LoadTextures(Content);

        // Sử dụng texturePlayer thay cho Content.Load<Texture2D>("player")
        _playerShip.Texture = Textures.texturePlayer;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Liên tục update speed cho các sprites --> Giúp chuyển động nhìn mượt và thống nhất
        float updatedPlayerShipSpeed = _playerShip.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        var kstate = Keyboard.GetState();

        // update vị trí các sprites theo chuyển động tương ứng
        _playerShip.Move(kstate, updatedPlayerShipSpeed);

        // Cập nhật vị trí của playerShip và kiểm tra việc bắn
        _playerShip.Update(gameTime, kstate, Textures.textureBulletP, 5f, _graphics); // 5f là tốc độ viên đạn

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Set RenderTarget để vẽ nội dung vào đó
        GraphicsDevice.SetRenderTarget(renderTarget);
        GraphicsDevice.Clear(Color.Indigo);

        _spriteBatch.Begin();
        SimplifyDrawing.HandleCentered(_spriteBatch, _playerShip.Texture, _playerShip.Position);
        foreach (var _bullet in _playerShip.Bullets)
        {
            SimplifyDrawing.HandleCentered(_spriteBatch, _bullet.Texture, _bullet.Position);
        }
        _spriteBatch.End();

        // Quay trở lại vẽ vào màn hình chính
        GraphicsDevice.SetRenderTarget(null);

        // Tính toán tỷ lệ để phóng lớn nội dung theo kích thước cửa sổ
        float scaleX = (float)Window.ClientBounds.Width / virtualWidth;
        float scaleY = (float)Window.ClientBounds.Height / virtualHeight;
        float scale = Math.Min(scaleX, scaleY); // Giữ nguyên tỷ lệ khung hình

        // Tính toán vị trí để vẽ nội dung ở giữa cửa sổ
        int scaledWidth = (int)(virtualWidth * scale);
        int scaledHeight = (int)(virtualHeight * scale);

        int offsetX = (Window.ClientBounds.Width - scaledWidth) / 2; // Khoảng trống bên trái và phải
        int offsetY = (Window.ClientBounds.Height - scaledHeight) / 2; // Khoảng trống bên trên và dưới

        // Vẽ nội dung của RenderTarget vào cửa sổ với tỷ lệ đã tính
        _spriteBatch.Begin();
        _spriteBatch.Draw(renderTarget,
                         new Rectangle(offsetX, offsetY, (int)(virtualWidth * scale), (int)(virtualHeight * scale)),
                         Color.White);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
