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

        // Quản lý cơ chế bắn đạn
        private float shootCoolDown;

        //Quản lý cơ chế di chuyển
        protected IMovementStrategy MovementStrategy;

        // Thêm tham chiếu đến Game1 --> Phục vụ game over và allBullets
        private Game1 _game;

        public Enemy(Game1 game, Texture2D texture, Vector2 position, IMovementStrategy movementStrategy)
        {
            _game = game;
            Texture = texture;
            Position = position;
            MovementStrategy = movementStrategy;
        }

        public void Shoot(GameTime gameTime)
        {
            float bulletSpeed = 3.5f;
            shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (shootCoolDown <= 0)
            {
                _game._allBullets.Add(new BulletEnemy(Textures.textureBulletE, new Vector2(Position.X, Position.Y), bulletSpeed));
                ResetShootCoolDown();
            }
        }
        private void ResetShootCoolDown()
        {
            Random random = new Random();
            shootCoolDown = (float)(random.NextDouble() * 1.5 + 3); // Giá trị ngẫu nhiên từ 3 đến 4.5 giây
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (!IsAlive) return; // Không cập nhật kẻ địch nếu nó đã bị tiêu diệt

            Shoot(gameTime);
            /* Bullets = Bullets.Where(b => b.Position.Y <= graphics.PreferredBackBufferHeight)
                             .Select(b => { b.Move(); return b; }).ToList(); */

            Position = MovementStrategy.Move(gameTime, graphics, Position);

            CheckCollisionWithBullets(_game._allBullets.OfType<BulletPlayer>().ToList());
        }

        private void CheckCollisionWithBullets(List<BulletPlayer> bullets)
        {
            var enemyBounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            bullets.RemoveAll(bullet =>
            {
                var bulletBounds = new Rectangle((int)bullet.Position.X, (int)bullet.Position.Y, bullet.Texture.Width, bullet.Texture.Height);

                if (enemyBounds.Intersects(bulletBounds))
                {
                    IsAlive = false; // Kẻ địch bị tiêu diệt
                    return true;
                }
                return false;
            });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}