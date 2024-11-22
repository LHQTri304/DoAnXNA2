using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public abstract class Enemy : IDamageable
    {
        private Game1 _game1;
        public int HP { get; set; }
        public HealthBar HealthBar { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        protected int ScoreKilled { get; set; }
        public bool IsAlive { get; set; } = true;

        private float _showHealthBarTimer; // Thời gian hiển thị HealthBar
        private const float HealthBarDisplayDuration = 2f; // Thời gian (giây) hiển thị thanh máu

        // Quản lý cơ chế di chuyển & bắn
        protected Random RandomIndex;
        protected List<IMovementStrategy> MovementStrategy;
        protected List<IBaseShootingStrategy> ShootingStrategy;

        public Enemy(Game1 game, Texture2D texture, Vector2 position, int scoreKilled, List<IMovementStrategy> movementStrategy, List<IBaseShootingStrategy> shootingStrategy)
        {
            _game1 = game;
            HP = shootingStrategy.Count switch
            {
                1 => HPStatsManager.EEasyHP,
                2 => HPStatsManager.EEliteHP,
                3 => HPStatsManager.EHardHP,
                _ => 1
            };
            HealthBar = new HealthBar(position, HP, texture.Width / 2, 0.5f);
            Texture = texture;
            Position = position;
            ScoreKilled = scoreKilled;
            MovementStrategy = movementStrategy;
            ShootingStrategy = shootingStrategy;
            RandomIndex = new Random();

            _showHealthBarTimer = 0; // Ban đầu HealthBar không được hiển thị
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            HealthBar.SetHP(HP);
            if (HP <= 0)
            {
                HP = 0;
                Soundtrack.EnemyKilled.Play(0.1f, 0f, 0f);
                _game1._currentScore += ScoreKilled;
                IsAlive = false; // Kẻ địch bị tiêu diệt
            }
            else
            {
                _showHealthBarTimer = HealthBarDisplayDuration; // Hiển thị HealthBar sau khi nhận sát thương
            }
        }

        private void CheckCollisions()
        {
            CheckCollisionQuick.EnemyVsBulletPlayer(_game1, this);
        }

        private void CheckOutOfScreen()
        {
            if (Position.Y > _game1.VirtualHeight + 50)
                IsAlive = false;
        }

        private void SetPositionHealthBar()
        {
            HealthBar.Position = Position + new Vector2(0, Texture.Height / 2);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (!IsAlive) return; // Không cập nhật kẻ địch nếu nó đã bị tiêu diệt

            // Cập nhật thời gian hiển thị HealthBar
            if (_showHealthBarTimer > 0)
                _showHealthBarTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            SetPositionHealthBar();
            HealthBar.Update(gameTime, HP, 1f);

            ShootingStrategy[RandomIndex.Next(ShootingStrategy.Count)].Shoot(gameTime, Position, _game1.AllBullets);
            Position = MovementStrategy[RandomIndex.Next(MovementStrategy.Count)].Move(gameTime, graphics, Position);
            CheckCollisions();
            CheckOutOfScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position, 0.6f);

                // Chỉ vẽ HealthBar nếu đang trong thời gian hiển thị
                if (_showHealthBarTimer > 0)
                    HealthBar.Draw(spriteBatch);
            }
        }
    }
}
