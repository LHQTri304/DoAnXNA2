using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.utilities;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public abstract class Enemy
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public bool IsAlive { get; set; } = true;

        //Quản lý cơ chế di chuyển & bắn
        protected IMovementStrategy MovementStrategy;
        protected IBaseShootingStrategy ShootingStrategy;

        // Thêm tham chiếu đến Game1 --> Phục vụ game over và allBullets
        private Game1 _game;

        public Enemy(Game1 game, Texture2D texture, Vector2 position, IMovementStrategy movementStrategy, IBaseShootingStrategy shootingStrategy)
        {
            _game = game;
            Texture = texture;
            Position = position;
            MovementStrategy = movementStrategy;
            ShootingStrategy = shootingStrategy;
        }

        private void CheckCollisionWithBullets()
        {
            _game._allBullets.OfType<BulletPlayer>().ToList().RemoveAll(bullet =>
            {
                return CollisionUtilities.CheckCollision(
                    Position, Texture,
                    bullet.Position, bullet.Texture,
                    () =>
                    {
                        IsAlive = false; // Kẻ địch bị tiêu diệt
                    }
                );
            });
        }

        private void CheckOutOfScreen()
        {
            if (Position.Y > _game.virtualHeight + 50)
                IsAlive = false;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (!IsAlive) return; // Không cập nhật kẻ địch nếu nó đã bị tiêu diệt

            ShootingStrategy.Shoot(gameTime, Position, _game._allBullets);
            Position = MovementStrategy.Move(gameTime, graphics, Position);
            CheckCollisionWithBullets();
            CheckOutOfScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}