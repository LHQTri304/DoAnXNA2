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
    private int virtualWidth = 540; // Chiều rộng cố định của nội dung game
    private int virtualHeight = 960;  // Chiều cao cố định của nội dung game
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;
    private GameHUD _gameHUD;

    //the sprites
    private PlayerShip _playerShip;
    private EnemySpawner _enemySpawner;


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
        //_graphics.IsFullScreen = true;  // Nếu muốn fullscreen, thêm dòng này

        // Tạo RenderTarget với kích thước cố định
        _renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);

        // Tạo các sprites
        _playerShip = new PlayerShip(null, new Vector2(100, 100), 100f);
        _enemySpawner = new EnemySpawner(3f); // Khởi tạo EnemySpawner với thời gian cooldown

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); //Tạo sprite batch        
        Textures.LoadTextures(Content); // Load tất cả các texture trong file texture2D.cs

        // Sử dụng texturePlayer thay cho Content.Load<Texture2D>("player")
        _playerShip.Texture = Textures.texturePlayer;

        // Khởi tạo GameHUD với font
        _gameHUD = new GameHUD(Content.Load<SpriteFont>("hudFontTest1"));
    }

    protected override void Update(GameTime _gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        var kstate = Keyboard.GetState();

        // Cập nhật các sprites
        _playerShip.Update(_gameTime, _graphics, kstate, Textures.textureBulletP, 5f); // 5f là tốc độ viên đạn
        _enemySpawner.Update(_gameTime, _graphics, Textures.textureEnemy, _playerShip.Bullets, Textures.textureBulletE, 3.5f);

        // Cập nhật GUI và HUD
        _gameHUD.Update(_gameTime, _enemySpawner.Enemies.Count);

        base.Update(_gameTime);
    }

    protected override void Draw(GameTime _gameTime)
    {
        GraphicsDevice.SetRenderTarget(_renderTarget);   // Set RenderTarget để vẽ nội dung vào đó
        GraphicsDevice.Clear(Color.Indigo);

        _spriteBatch.Begin();
        _playerShip.Draw(_spriteBatch);
        foreach (var _bulletP in _playerShip.Bullets)
        {
            _bulletP.Draw(_spriteBatch);
        }
        foreach (var _enemy in _enemySpawner.Enemies)
        {
            _enemy.Draw(_spriteBatch);
        foreach (var _bulletE in _enemy.Bullets)
        {
            _bulletE.Draw(_spriteBatch);
        }
        }
        _gameHUD.Draw(_spriteBatch, Textures.textureHP);    // Vẽ HUD
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);   // Kết thúc RenderTarget. Quay trở lại vẽ vào màn hình chính

        //#### SCALING SCREEN FLEXIBLE - BEGIN ####//
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
        _spriteBatch.Draw(_renderTarget,
                         new Rectangle(offsetX, offsetY, (int)(virtualWidth * scale), (int)(virtualHeight * scale)),
                         Color.White);
        _spriteBatch.End();
        //#### SCALING SCREEN FLEXIBLE - END ####//

        base.Draw(_gameTime);
    }
}
