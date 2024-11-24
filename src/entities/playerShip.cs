using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public class PlayerShip : IDamageable
    {
        public int HP { get; set; }
        public HealthBar HealthBar { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentLevel { get; set; }

        // Quản lý bắn đạn
        private IPlayerShootingStrategy ShootingStrategy;


        public PlayerShip()
        {
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
            ShootingStrategy = new StraightShot(CurrentLevel);
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                //MainRes.GSM.SetGameOver();
            }
        }

        private void CheckCollisions()
        {
            CheckCollisionQuick.PlayerVsBulletEnemy();
            CheckCollisionQuick.PlayerVsEnemy();
        }

        public void Update(GameTime gameTime, KeyboardState kstate, MouseState mstate)
        {
            // Level up khi đạt Milestone
            if (CurrentLevel < 10 && MainRes.CurrentScore == ScoreTable.MilestoneLv0to10[CurrentLevel + 1])
            {
                CurrentLevel++;
                SetShootingStrategy();
            }

            // Di chuyển & Giới hạn vị trí player trong cửa sổ
            Position = MovementPlayerUtilities.GetNewPosition(Position, mstate);
            Position = MovementPlayerUtilities.KeepPlayerInsideWindow(Position, Texture);

            // Xử lý bắn
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ShootingStrategy.Shoot(elapsedTime, mstate, Position, MainRes.AllBullets);

            // Xử lý va chạm
            CheckCollisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}
