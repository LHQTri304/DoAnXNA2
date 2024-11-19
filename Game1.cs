using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2;
public class Game1 : Game
{
    public GraphicsDeviceManager _graphics { get; private set; }
    public int virtualWidth { get; private set; } = 1280; // Chiều rộng cố định của nội dung game
    public int virtualHeight { get; private set; } = 720;// Chiều cao cố định của nội dung game
    public Song _backgroundMusic { get; set; }
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;

    //GameState
    public bool _isGameOver { get; private set; }
    private GameState _currentState;
    private GameState _previousState;
    private MainMenu _mainMenu;
    private Setting _setting;
    private ChoosingLevels _choosingLevels;
    private GameDisplay _gameDisplay;
    private GameOver _gameOver;

    //the sprites
    public PlayerShip _playerShip { get; set; }
    public List<EnemySpawner> _allSpawners { get; set; }
    public List<Bullet> _allBullets { get; set; } = [];

    // UI - UX
    public Cursor _cursor { get; set; }
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
        _cursor = new Cursor();

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
        Textures.LoadAll(Content); // Load tất cả các texture trong file texture2D.cs
        Soundtrack.LoadAll(Content); // Load tất cả các soundtrack trong file soundtrack.cs
        ReadyMadeBtn.InitAndLoad(this); // Load tất cả các Button thường dùng
        _font = SpriteFonts.LoadSpriteFonts(Content); // Load tất cả các font hiện có (1 cái duy nhất)

        //tránh lỗi null khi run
        _playerShip.ReloadTexture();
        _cursor.ReloadTexture();

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

        //Background music
        _backgroundMusic = Soundtrack.TitleTheme;
        if (MediaPlayer.State != MediaState.Playing)
        {
            MediaPlayer.Play(_backgroundMusic);
            MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = 0.5f;  // Điều chỉnh âm lượng (0.0 đến 1.0)
        }
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
    public void SetMainMenu()
    {
        _previousState = _currentState;
        _backgroundMusic = Soundtrack.TitleTheme;
        _currentState = _mainMenu;
    }
    public void SetSetting()
    {
        _previousState = _currentState;
        _backgroundMusic = Soundtrack.TitleTheme;
        _currentState = _setting;
    }
    public void SetChoosingLevels()
    {
        _previousState = _currentState;
        _backgroundMusic = Soundtrack.TitleTheme;
        _currentState = _choosingLevels;
    }
    public void SetGameDisplay(int level)
    {
        _previousState = _currentState;
        _backgroundMusic = RandomCombatTheme();
        _gameDisplay._Level = level;
        _currentScore = 0;
        _playerShip.ResetLevel();
        _allBullets.Clear();
        foreach (var item in _allSpawners)
            item.Enemies.Clear();
        _currentState = _gameDisplay;
    }
    public void SetGameOver()
    {
        _previousState = _currentState;
        _backgroundMusic = Soundtrack.GameOver;
        _currentState = _gameOver;
    }
    public void SetStateBackward()
    {
        _currentState = _previousState;
    }
    private Song RandomCombatTheme()
    {
        int index = new Random().Next(1, 5);
        return index switch
        {
            1 => Soundtrack.CombatTheme1,
            2 => Soundtrack.CombatTheme2,
            3 => Soundtrack.CombatTheme3,
            4 => Soundtrack.CombatTheme4,
            _ => Soundtrack.CombatTheme1,
        };
    }
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
