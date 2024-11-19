using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2
{
    public class PlayerShip
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentLevel { get; set; }
        public bool IsAlive { get; set; }

        // Quản lý bắn đạn
        protected IPlayerShootingStrategy ShootingStrategy;


        // Thêm tham chiếu đến Game1 --> Phục vụ game over và allBullets
        private Game1 _game;

        public PlayerShip(Game1 game)
        {
            _game = game;
            Texture = null;
            Position = new(0, 0);
            IsAlive = true;
            ResetLevel();
        }

        public void ReloadTexture()
        {
            Texture = Textures.Player;
        }

        public void ResetLevel()
        {
            CurrentLevel = 1;
            SetShootingStrategy();
        }

        public void SetShootingStrategy()
        {
            ShootingStrategy = new ConicalShot(CurrentLevel);
        }

        private void CheckCollisions()
        {
            CheckCollisionQuick.PlayerVsBulletEnemy(this, _game._allBullets, () =>
                    {
                        System.Diagnostics.Debug.WriteLine("bạn đã bị bắn");
                        IsAlive = false;
                        _game.SetGameOver(); //Cập nhật trạng thái game
                    });

            CheckCollisionQuick.PlayerVsEnemy(this, _game._allSpawners, () =>
                    {
                        System.Diagnostics.Debug.WriteLine("bạn đã bị bắn");
                        IsAlive = false;
                        _game.SetGameOver(); //Cập nhật trạng thái game
                    });
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate, MouseState mstate)
        {
            // Level up khi đạt Milestone
            if (CurrentLevel < 10 && _game._currentScore == ScoreTable.MilestoneLv0to10[CurrentLevel + 1])
            {
                CurrentLevel++;
                SetShootingStrategy();
            }

            // Di chuyển & Giới hạn vị trí player trong cửa sổ
            Position = MovementPlayerUtilities.GetNewPosition(Position, mstate);
            Position = MovementPlayerUtilities.KeepPlayerInsideWindow(graphics, Position, Texture);

            // Xử lý bắn
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ShootingStrategy.Shoot(elapsedTime, mstate, Position, _game._allBullets);

            // Xử lý va chạm
            CheckCollisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleRotatingTexture(spriteBatch, Texture, Position, 1000f);
        }
    }
}
