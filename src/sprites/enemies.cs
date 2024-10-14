using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using DoAnXNA2.src.utilities;
using System;

namespace DoAnXNA2.src.sprites
{
    public class Enemy
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public bool IsAlive { get; private set; } = true;

        //Quản lý di chuyển ngẫu nhiên
        private float horizontalOffset; // Biến để lưu giá trị ngẫu nhiên (Perlin noise)
        private static float perlinNoiseOffset = 0; // Giá trị để tính Perlin noise cho mỗi kẻ địch
        private float horizontalSpeed; // Tốc độ di chuyển ngang

        // Quản lý cơ chế bắn đạn
        public List<BulletEnemy> Bullets { get; private set; } = new List<BulletEnemy>();
        private float shootCoolDown;
        private const float shootCoolDownTime = 3f;

        // Quản lý giới hạn di chuyển bên trong màn hình
        private bool isCollidedWithLeftWall;
        private bool isCollidedWithRightWall;
        private float wallCollisionCoolDown;
        private const float wallCollisionCoolDownTime = 0.75f;

        public Enemy(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            horizontalOffset = perlinNoiseOffset;
            perlinNoiseOffset += 0.03f;
            horizontalSpeed = 55f;
        }

        public void Shoot(GameTime gameTime, Texture2D bulletTexture, float bulletSpeed)
        {
            shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (shootCoolDown <= 0)
            {
                Bullets.Add(new BulletEnemy(bulletTexture, new Vector2(Position.X, Position.Y), bulletSpeed));
                shootCoolDown = shootCoolDownTime;
            }
        }

        public void MoveAfterCollisionWithWall(GameTime gameTime, GraphicsDeviceManager graphics, float moveValue)
        {
            if (Position.X < Texture.Width / 2)
            {
                isCollidedWithLeftWall = true;
                wallCollisionCoolDown = wallCollisionCoolDownTime;
            }
            else if (Position.X > graphics.PreferredBackBufferWidth - Texture.Width / 2)
            {
                isCollidedWithRightWall = true;
                wallCollisionCoolDown = wallCollisionCoolDownTime;
            }

            if (wallCollisionCoolDown > 0)
            {
                Position += isCollidedWithLeftWall
                    ? new Vector2(Math.Abs(moveValue), 0)
                    : new Vector2(-Math.Abs(moveValue), 0);

                wallCollisionCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                isCollidedWithLeftWall = false;
                isCollidedWithRightWall = false;
                Position += new Vector2(moveValue, 0);
            }
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, List<BulletPlayer> bullets, List<Enemy> enemies, Texture2D bulletTexture, float bulletSpeed)
        {
            if (!IsAlive) return; // Không cập nhật kẻ địch nếu nó đã bị tiêu diệt

            Shoot(gameTime, bulletTexture, bulletSpeed);
            Bullets = Bullets.Where(b => b.Position.Y <= graphics.PreferredBackBufferHeight)
                             .Select(b => { b.Move(); return b; }).ToList();

            // Auto di chuyển dọc
            Position += new Vector2(0, Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

            // Di chuyển ngang ngẫu nhiên và không vượt ra khỏi màn hình
            float perlinValue = MathHelper.Lerp(-1, 1, (float)SimplexNoise.Noise.CalcPixel2D((int)horizontalOffset, 0, 0.05f) / 255f);
            horizontalOffset += 0.1f;
            float moveValue = perlinValue * horizontalSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            MoveAfterCollisionWithWall(gameTime, graphics, moveValue);

            // Xóa kẻ địch nếu ra khỏi màn hình
            if (Position.Y > graphics.PreferredBackBufferHeight + 50)
            {
                IsAlive = false;
            }

            CheckCollisionWithBullets(bullets);
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
