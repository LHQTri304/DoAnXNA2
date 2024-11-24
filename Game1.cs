using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2;
public class Game1 : Game
{
    public GraphicsDeviceManager Graphics { get; private set; }
    public int VirtualWidth { get; private set; } = 1280; // Chiều rộng cố định của nội dung game
    public int VirtualHeight { get; private set; } = 720;// Chiều cao cố định của nội dung game
    public Song BackgroundMusic { get; set; }
    private RenderTarget2D _renderTarget;
    private SpriteBatch _spriteBatch;

    //GameState
    public bool IsAbleToWin { get; set; }
    private GameState _currentState;
    private GameState _previousState;
    private MainMenu _mainMenu;
    private Setting _setting;
    private ChoosingLevels _choosingLevels;
    private GameDisplay _gameDisplay;
    private GameOver _gameOver;
    private Victory _victory;
    private ComingSoon _comingSoon;

    //the sprites
    public PlayerShip PlayerShip { get; set; }
    public Dictionary<string, EnemySpawner> AllSpawners { get; set; } = [];
    private List<string> _enemyNames =
        [
            "Yellow", "Red", "Green", "Blue", "Orange", "Purple", "Gray", "Cyan", 
            "Pink", "Brown", "Teal", "Lime", "Black", "White", "Gold", "Silver", 
            "Maroon", "Navy"
        ];

    public List<Enemy> AllEnemies { get; set; } = [];
    public List<Bullet> AllBullets { get; set; } = [];

    // UI - UX
    public Cursor Cursor { get; set; }
    public List<I_HUD> GameHUD { get; set; }
    public SpriteFont Font { get; set; }

    // Level system
    public int _currentScore { get; set; }

    public Game1()
    {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // Thiết lập kích thước của cửa sổ
        Graphics.PreferredBackBufferWidth = VirtualWidth;
        Graphics.PreferredBackBufferHeight = VirtualHeight;
        Graphics.ApplyChanges();
        Window.AllowUserResizing = true; // Cho phép Resize
        IsMouseVisible = false; // Ẩn con trỏ chuột

        // Tạo RenderTarget với kích thước cố định
        _renderTarget = new RenderTarget2D(GraphicsDevice, VirtualWidth, VirtualHeight);

        //Flags
        IsAbleToWin = false;

        // Tạo các sprites
        PlayerShip = new PlayerShip(this);
        Cursor = new Cursor();

        // Khởi tạo spawner --> Dùng ánh xạ (Reflection) để tạo tự động
        foreach (var eName in _enemyNames)
        {
            // Tìm kiếm lớp có tên tương ứng với màu (ví dụ: YellowSpawner cho "Yellow")
            string className = "DoAnXNA2." + eName + "Spawner";
            Type spawnerType = Type.GetType(className);

            if (spawnerType != null)
            {
                // Tạo đối tượng spawner từ lớp tìm được
                var spawnerInstance = (EnemySpawner)Activator.CreateInstance(spawnerType, this);
                AllSpawners.Add(eName, spawnerInstance);
            }
            else
                Console.WriteLine($"Lớp {className} không tồn tại.");
        }

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); //Tạo sprite batch        
        Textures.LoadAll(Content); // Load tất cả các texture trong file texture2D.cs
        Soundtrack.LoadAll(Content); // Load tất cả các soundtrack trong file soundtrack.cs
        ReadyMadeBtn.InitAndLoad(this); // Load tất cả các Button thường dùng
        Font = SpriteFonts.LoadSpriteFonts(Content); // Load tất cả các font hiện có (1 cái duy nhất)

        //tránh lỗi null khi run
        PlayerShip.ReloadTexture();
        Cursor.ReloadTexture();

        // GameState (Screen)
        _mainMenu = new MainMenu(this);
        _setting = new Setting(this);
        _choosingLevels = new ChoosingLevels(this);
        _gameDisplay = new GameDisplay(this);
        _gameOver = new GameOver(this);
        _victory = new Victory(this);
        _comingSoon = new ComingSoon(this);
        _currentState = _mainMenu;

        // UI
        GameHUD = [
            new NextLevelMilestoneHUD(this, Font),
            new GameScoreHUD(this, Font),
        ];

        //Background music
        BackgroundMusic = Soundtrack.TitleTheme;
        if (MediaPlayer.State != MediaState.Playing)
        {
            MediaPlayer.Play(BackgroundMusic);
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
        DrawScaledScreen(_spriteBatch, _renderTarget, VirtualWidth, VirtualHeight);

        base.Draw(_gameTime);
    }
    public void SetMainMenu()
    {
        _previousState = _currentState;
        BackgroundMusic = Soundtrack.TitleTheme;
        _currentState = _mainMenu;
    }
    public void SetSetting()
    {
        _previousState = _currentState;
        BackgroundMusic = Soundtrack.TitleTheme;
        _currentState = _setting;
    }
    public void SetChoosingLevels()
    {
        _previousState = _currentState;
        BackgroundMusic = Soundtrack.TitleTheme;
        _choosingLevels.StartLoading();
        _currentState = _choosingLevels;
    }
    public void SetGameDisplay(int level)
    {
        _previousState = _currentState;
        BackgroundMusic = RandomCombatTheme();
        _gameDisplay.CurrentLevel = level;
        _gameDisplay.RenewListLevels();
        _currentScore = 0;
        PlayerShip.ResetStats();
        AllBullets.Clear();
        AllEnemies.Clear();
        _currentState = _gameDisplay;
    }
    public void SetGameOver()
    {
        _previousState = _currentState;
        BackgroundMusic = Soundtrack.GameOver;
        IsAbleToWin = false;
        _currentState = _gameOver;
    }
    public void SetVictory()
    {
        _previousState = _currentState;
        BackgroundMusic = Soundtrack.GameOver;
        IsAbleToWin = false;
        _currentState = _victory;
    }
    public void SetComingSoon()
    {
        _previousState = _currentState;
        BackgroundMusic = Soundtrack.GameOver;
        IsAbleToWin = false;
        _currentState = _comingSoon;
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
