using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.utilities;
using DoAnXNA2.src.components;

namespace DoAnXNA2;

public enum GameState
{
    MainMenu,
    GameDisplay,
    GameOver
}


public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private int virtualWidth = 540; // Chiều rộng cố định của nội dung game
    private int virtualHeight = 960;  // Chiều cao cố định của nội dung game
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;
    private GameHUD _gameHUD;

    //GameState
    private Button _startButton, _returnButton; // Nút Start và nút Return
    private GameState currentGameState; // Trạng thái hiện tại của trò chơi
    private bool _isGameOver; // Flag game over

    //the sprites
    private PlayerShip _playerShip;
    private EnemySpawner _enemySpawner;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        currentGameState = GameState.MainMenu; // Bắt đầu với MainMenu
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

        //Flags
        _isGameOver = false;

        // Tạo các sprites
        _playerShip = new PlayerShip(this, null, new Vector2(100, 100), 100f);
        _enemySpawner = new EnemySpawner(3f); // Khởi tạo EnemySpawner với thời gian cooldown

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); //Tạo sprite batch        
        Textures.LoadTextures(Content); // Load tất cả các texture trong file texture2D.cs

        _playerShip.Texture = Textures.texturePlayer; //Thêm Texture sau khi load, tránh lỗi null khi  và run

        //GameState
        _startButton = new Button(Textures.startButton, new Vector2(270, 480));
        _returnButton = new Button(Textures.returnButton, new Vector2(270, 480));

        _gameHUD = new GameHUD(Content.Load<SpriteFont>("hudFontTest1"));// Khởi tạo GameHUD với font
    }

    protected override void Update(GameTime _gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        var kstate = Keyboard.GetState();

        switch (currentGameState)
        {
            case GameState.MainMenu:
                InputUtilities.HandleKeyPress(Keys.Space, kstate, () => { currentGameState = GameState.GameDisplay; }); // Nhấn space để start
                break;

            case GameState.GameDisplay:
                // Cập nhật các sprites
                _playerShip.Update(_gameTime, _graphics, kstate, _enemySpawner.Enemies.SelectMany(e => e.Bullets).ToList(), Textures.textureBulletP, 5f); // 5f là tốc độ viên đạn
                _enemySpawner.Update(_gameTime, _graphics, Textures.textureEnemy, _playerShip.Bullets, Textures.textureBulletE, 3.5f);

                // Cập nhật GUI và HUD
                _gameHUD.Update(_gameTime, _enemySpawner.Enemies.Count);

                // Kiểm tra va chạm giữa viên đạn của kẻ địch và tàu người chơi
                foreach (var _enemy in _enemySpawner.Enemies)
                    _playerShip.CheckCollisionWithBulletEnemy(_enemy.Bullets);

                //if (kstate.IsKeyDown(Keys.G)) // Nhấn G để chuyển sang GameOver
                if (_isGameOver)
                    currentGameState = GameState.GameOver;
                break;

            case GameState.GameOver:
                InputUtilities.HandleKeyPress(Keys.Space, kstate, () => SetRestart()); // Nhấn space để chuyển sang main menu
                break;
        }

        base.Update(_gameTime);
    }

    protected override void Draw(GameTime _gameTime)
    {
        GraphicsDevice.SetRenderTarget(_renderTarget);   // Set RenderTarget để vẽ nội dung vào đó
        GraphicsDevice.Clear(Color.Indigo);

        _spriteBatch.Begin();
        var spriteFont = Content.Load<SpriteFont>("hudFontTest1");
        switch (currentGameState)
        {
            case GameState.MainMenu:
                SimplifyDrawing.HandleCenteredText(_spriteBatch, spriteFont, "MAIN MENU", new Vector2(virtualWidth / 2, virtualHeight / 2 - 200));
                SimplifyDrawing.HandleCenteredText(_spriteBatch, spriteFont, "Press Space to Start", new Vector2(virtualWidth / 2, virtualHeight / 2));
                //_spriteBatch.Draw(Textures.texturePlayer, new Vector2(270, 400), Color.White); // Hình ảnh playerShip
                //_startButton.Draw(_spriteBatch);
                break;

            case GameState.GameDisplay:
                _playerShip.Draw(_spriteBatch);
                foreach (var _bulletP in _playerShip.Bullets)
                    _bulletP.Draw(_spriteBatch);
                foreach (var enemy in _enemySpawner.Enemies)
                {
                    enemy.Draw(_spriteBatch);
                    foreach (var bullet in enemy.Bullets)
                        bullet.Draw(_spriteBatch);
                }
                //_gameHUD.Draw(_spriteBatch, Textures.textureHP);
                break;

            case GameState.GameOver:
                SimplifyDrawing.HandleCenteredText(_spriteBatch, spriteFont, "GAME OVER", new Vector2(virtualWidth / 2, virtualHeight / 2 - 200));
                SimplifyDrawing.HandleCenteredText(_spriteBatch, spriteFont, "Press Space to Return Main Menu", new Vector2(virtualWidth / 2, virtualHeight / 2));
                //_returnButton.Draw(_spriteBatch);
                break;
        }
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

    public void SetGameOver()
    {
        _isGameOver = true;
        currentGameState = GameState.GameOver;
    }
    public void SetRestart()
    {
        _isGameOver = false;
        currentGameState = GameState.MainMenu;

    // Reset danh sách đạn của player
    _playerShip.Bullets.Clear();

    // Reset kẻ địch và đạn của kẻ địch
    _enemySpawner.Enemies.Clear();
    }
}
