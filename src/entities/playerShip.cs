using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2
{
    public class PlayerShip : IDamageable
    {
        private Game1 _game1;
        public int HP { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentLevel { get; set; }

        // Quản lý bắn đạn
        private IPlayerShootingStrategy ShootingStrategy;


        public PlayerShip(Game1 game)
        {
            _game1 = game;
            ResetStats();
            Texture = null;
            Position = new(0, 0);
        }

        public void ReloadTexture()
        {
            Texture = Textures.Player;
        }

        public void ResetStats()
        {
            HP = HPStatsManager.PlayerHP;
            CurrentLevel = 1;
            SetShootingStrategy();
        }

        public void SetShootingStrategy()
        {
            ShootingStrategy = new ConicalShot(CurrentLevel);
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                //_game1.SetGameOver();
            }
        }

        private void CheckCollisions()
        {
            CheckCollisionQuick.PlayerVsBulletEnemy(_game1);
            CheckCollisionQuick.PlayerVsEnemy(_game1);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate, MouseState mstate)
        {
            // Level up khi đạt Milestone
            if (CurrentLevel < 10 && _game1._currentScore == ScoreTable.MilestoneLv0to10[CurrentLevel + 1])
            {
                CurrentLevel++;
                SetShootingStrategy();
            }

            // Di chuyển & Giới hạn vị trí player trong cửa sổ
            Position = MovementPlayerUtilities.GetNewPosition(Position, mstate);
            Position = MovementPlayerUtilities.KeepPlayerInsideWindow(graphics, Position, Texture);

            // Xử lý bắn
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ShootingStrategy.Shoot(elapsedTime, mstate, Position, _game1._allBullets);

            // Xử lý va chạm
            CheckCollisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleRotatingTexture(spriteBatch, Texture, Position, 1000f);
        }
    }
}
