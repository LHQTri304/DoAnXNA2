using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.utilities;
using DoAnXNA2.src.components;
using DoAnXNA2.src.gameState;
using DoAnXNA2.src.spawners;
using DoAnXNA2.src.UI;
using Microsoft.Xna.Framework.Content;

namespace DoAnXNA2;
public class Game1 : Game
{
    public GraphicsDeviceManager _graphics { get; }
    public int virtualWidth { get; } = 1280; // Chiều rộng cố định của nội dung game
    public int virtualHeight { get; } = 720;// Chiều cao cố định của nội dung game
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;

    //GameState
    public bool _isGameOver { get; private set; }
    private GameState _currentState;
    private MainMenu _mainMenu;
    private Setting _setting;
    private ChoosingLevels _choosingLevels;
    private GameDisplay _gameDisplay;
    private GameOver _gameOver;

    //the sprites
    public PlayerShip _playerShip { get; set; }
    public List<EnemySpawner> _allSpawners { get; set; }
    public List<Bullet> _allBullets { get; set; } = [];

    // UI
    public List<I_HUD> _gameHUD { get; set; }
    public SpriteFont _font { get; set; }

    // Level system
    public int _currentScore { get; set; }

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
        Window.AllowUserResizing = true; // Cho phép Resize
        IsMouseVisible = false; // Ẩn con trỏ chuột

        // Tạo RenderTarget với kích thước cố định
        _renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);

        //Flags
        _isGameOver = false;

        // Tạo các sprites
        _playerShip = new PlayerShip(this);

        // Khởi tạo spawner
        _allSpawners = [
            new YellowSpawner(this),
            new RedSpawner(this),
            new GreenSpawner(this)
        ];

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); //Tạo sprite batch        
        Textures.LoadTextures(Content); // Load tất cả các texture trong file texture2D.cs
        _font = SpriteFonts.LoadSpriteFonts(Content); // Load tất cả các font hiện có (1 cái duy nhất)
        _playerShip.ReloadTexture(); //tránh lỗi null khi run

        // GameState (Screen)
        _mainMenu = new MainMenu(this);
        _setting = new Setting(this);
        _choosingLevels = new ChoosingLevels(this);
        _gameDisplay = new GameDisplay(this);
        _gameOver = new GameOver(this);
        _currentState = _mainMenu;

        // UI
        _gameHUD = [
            new NextLevelMilestoneHUD(this, _font),
            new GameScoreHUD(this, _font),
        ];
    }

    protected override void Update(GameTime _gameTime)
    {
        _currentState.Update(_gameTime);
        base.Update(_gameTime);
    }

    protected override void Draw(GameTime _gameTime)
    {
        //Dùng RenderTarget vẽ màn hình theo kích thước tùy ý
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.Indigo);

        //Nội dung màn hình
        _spriteBatch.Begin();
        _currentState.Draw(_spriteBatch);
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        DrawScaledScreen(_spriteBatch, _renderTarget, virtualWidth, virtualHeight);

        base.Draw(_gameTime);
    }
    public void SetMainMenu() => _currentState = _mainMenu;
    public void SetSetting() => _currentState = _setting;
    public void SetChoosingLevels() => _currentState = _choosingLevels;
    public void SetGameDisplay(int level)
    {
        _gameDisplay._Level = level;
        _currentScore = 0;
        _playerShip.ResetLevel();
        _allBullets.Clear();
        foreach (var item in _allSpawners)
            item.Enemies.Clear();
        _currentState = _gameDisplay;
    }
    public void SetGameOver() => _currentState = _gameOver;
    private void DrawScaledScreen(SpriteBatch spriteBatch, RenderTarget2D renderTarget, int virtualWidth, int virtualHeight)
    {
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
        spriteBatch.Begin();
        spriteBatch.Draw(renderTarget,
                         new Rectangle(offsetX, offsetY, scaledWidth, scaledHeight),
                         Color.White);
        spriteBatch.End();
    }

}
