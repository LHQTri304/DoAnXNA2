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
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        protected int ScoreKilled { get; set; }
        public bool IsAlive { get; set; } = true;

        //Quản lý cơ chế di chuyển & bắn
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
                _ => 10
            };
            Texture = texture;
            Position = position;
            ScoreKilled = scoreKilled;
            MovementStrategy = movementStrategy;
            ShootingStrategy = shootingStrategy;
            RandomIndex = new Random();
        }


        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                Soundtrack.EnemyKilled.Play(0.1f, 0f, 0f);
                _game1._currentScore += ScoreKilled;
                IsAlive = false; // Kẻ địch bị tiêu diệt
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

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (!IsAlive) return; // Không cập nhật kẻ địch nếu nó đã bị tiêu diệt

            ShootingStrategy[RandomIndex.Next(ShootingStrategy.Count)].Shoot(gameTime, Position, _game1.AllBullets);
            Position = MovementStrategy[RandomIndex.Next(MovementStrategy.Count)].Move(gameTime, graphics, Position);
            CheckCollisions();
            CheckOutOfScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position, 0.6f);
        }
    }
}