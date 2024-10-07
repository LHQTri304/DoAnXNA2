using System;
using System.Collections.Generic;
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
    private List<Enemy> _enemies;
    private Random _randomEnemiesSpawnX;

    // Test HUD
    SpriteFont font; // Dùng để vẽ chữ
    TimeSpan gameTimeElapsed; // Đồng hồ thời gian
    int enemyCount; // Giả sử số lượng kẻ địch
    float playerHealth = 100; // Thanh máu nhân vật
    Random random = new Random(); // Dùng để ngẫu nhiên hóa thanh máu

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
        Window.AllowUserResizing = true;    // Cho phép thay đổi kích thước cửa sổ        
        _graphics.IsFullScreen = true;  // Nếu muốn fullscreen, thêm dòng này

        // Tạo RenderTarget với kích thước cố định
        renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);

        // Tạo các sprites
        _playerShip = new PlayerShip(null, new Vector2(100, 100), 1000f);
        _enemies = new List<Enemy>();
        _randomEnemiesSpawnX = new Random();
        enemyCount = _enemies.Count;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load tất cả các texture trong file texture2D.cs
        Textures.LoadTextures(Content);

        // Sử dụng texturePlayer thay cho Content.Load<Texture2D>("player")
        _playerShip.Texture = Textures.texturePlayer;

        // Test HUD
        font = Content.Load<SpriteFont>("hudFontTest1"); // Font để hiển thị văn bản  
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

        // Test HUD
        // Cập nhật thời gian chơi
        gameTimeElapsed += gameTime.ElapsedGameTime;

        // Ngẫu nhiên tăng giảm thanh máu
        playerHealth += (float)(random.NextDouble() * 2 - 1); // Tăng giảm ngẫu nhiên
        playerHealth = MathHelper.Clamp(playerHealth, 0, 100); // Giới hạn từ 0 đến 100

        // Kiểm tra nếu người chơi nhấn phím M để spawn kẻ địch
        InputUtilities.HandleKeyPress(Keys.M, kstate, () => SpawnEnemy());

        // Cập nhật vị trí các kẻ địch
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            _enemies[i].Update(gameTime, _playerShip.Bullets, _enemies, _graphics);
            enemyCount = _enemies.Count;
        }

        base.Update(gameTime);
    }

    private void SpawnEnemy()
    {
        // Sinh ra vị trí x ngẫu nhiên trong phạm vi chiều ngang khung hình
        float randomX = _randomEnemiesSpawnX.Next(0, _graphics.PreferredBackBufferWidth);

        // Tạo kẻ địch mới ở vị trí (randomX, -50) với tốc độ di chuyển dọc 100f
        Vector2 enemyPosition = new Vector2(randomX, -50);
        Enemy newEnemy = new Enemy(Textures.textureEnemy, enemyPosition, 100f);

        // Thêm kẻ địch mới vào danh sách
        _enemies.Add(newEnemy);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Set RenderTarget để vẽ nội dung vào đó
        GraphicsDevice.SetRenderTarget(renderTarget);
        GraphicsDevice.Clear(Color.Indigo);

        _spriteBatch.Begin();
        _playerShip.Draw(_spriteBatch);
        foreach (var _bullet in _playerShip.Bullets)
        {
            _bullet.Draw(_spriteBatch);
        }
        foreach (var enemy in _enemies)
        {
            enemy.Draw(_spriteBatch);
        }

        // Test HUD
        // Hiển thị đồng hồ thời gian
        string timeText = $"Time: {gameTimeElapsed.TotalSeconds:F2}";
        Textures.customFont.DrawText(_spriteBatch, timeText, new Vector2(10, 10), Color.White);

        // Hiển thị số lượng kẻ địch
        string enemyText = $"Enemies: {enemyCount}";
        _spriteBatch.DrawString(font, enemyText, new Vector2(10, 40), Color.White);

        // Hiển thị thanh máu
        int healthBarWidth = (int)(playerHealth / 100 * 200); // Chiều rộng thanh máu dựa trên sức khỏe
        _spriteBatch.Draw(Textures.textureHP, new Rectangle(10, 70, healthBarWidth, 20), Color.Red);
        // Hết HUD

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
