using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.utilities;
using DoAnXNA2.src.components;
using DoAnXNA2.src.gameState;
using DoAnXNA2.src.spawners;
using System.Collections.Generic;

namespace DoAnXNA2;
public class Game1 : Game
{
    public GraphicsDeviceManager _graphics { get; }
    public int virtualWidth { get; } = 540; // Chiều rộng cố định của nội dung game
    public int virtualHeight { get; } = 960;// Chiều cao cố định của nội dung game
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;
    private GameHUD _gameHUD;

    //GameState
    public bool _isGameOver { get; private set; } // Flag game over
    private IGameState _currentState;
    private MainMenu _mainMenu;
    private Setting _setting;
    private ChoosingLevels _choosingLevels;
    private GameDisplay _gameDisplay;
    private GameOver _gameOver;

    //the sprites
    private PlayerShip _playerShip;
    private EnemySpawner _enemySpawner;
    public List<Bullet> _allBullets { get; set; } = [];

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

        // Tạo RenderTarget với kích thước cố định
        _renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);

        //Flags
        _isGameOver = false;

        // Tạo các sprites
        _playerShip = new PlayerShip(this, new Vector2(100, 100), 100f);

        // Khởi tạo vị trí spawn cố định cho kẻ địch
        _enemySpawner = new EnemySpawner(this);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); //Tạo sprite batch        
        Textures.LoadTextures(Content); // Load tất cả các texture trong file texture2D.cs

        _playerShip.Texture = Textures.texturePlayer; //Thêm Texture sau khi load, tránh lỗi null khi  và run

        var font = Content.Load<SpriteFont>("hudFontTest1");
        _gameHUD = new GameHUD(font);
        _mainMenu = new MainMenu(font);
        _setting = new Setting(font);
        _choosingLevels = new ChoosingLevels(font);
        _gameDisplay = new GameDisplay(this, _playerShip, _enemySpawner, _gameHUD);
        _gameOver = new GameOver(font);
        _currentState = _mainMenu;
    }

    protected override void Update(GameTime _gameTime)
    {
        /* if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit(); */
        var kstate = Keyboard.GetState();        
        _currentState.Update(this, _gameTime, kstate);
        base.Update(_gameTime);
    }

    protected override void Draw(GameTime _gameTime)
    {
        GraphicsDevice.SetRenderTarget(_renderTarget);   // Set RenderTarget để vẽ nội dung vào đó
        GraphicsDevice.Clear(Color.Indigo);

        _spriteBatch.Begin();
        _currentState.Draw(this, _spriteBatch);
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
    public void SetMainMenu()
    {
        _currentState = _mainMenu;
        //_playerShip.Bullets.Clear();
        _allBullets.Clear();
        _enemySpawner.Enemies.Clear();
    }
    public void SetSetting() => _currentState = _setting;
    public void SetChoosingLevels() => _currentState = _choosingLevels;
    public void SetGameDisplay(int level) => _currentState = _gameDisplay;
    public void SetGameOver() => _currentState = _gameOver;
}
