// enemies.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;
using System;

namespace DoAnXNA2.src.sprites
{
    public class Enemy
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        private float horizontalOffset; // Biến để lưu giá trị ngẫu nhiên (Perlin noise)
        private static float perlinNoiseOffset = 0; // Giá trị để tính Perlin noise cho mỗi kẻ địch
        private float horizontalSpeed; // Tốc độ di chuyển ngang

        // Quản lý đạn & cooldown bắn
        public List<BulletPlayer> Bullets { get; set; }
        private float shootCoolDown;
        private float shootCoolDownTime = 1f; // thời gian chờ giữa các lần bắn

        // Quản lý chuyển động khi va chạm tường
        private bool isCollidedWithLeftWall;
        private bool isCollidedWithRightWall;
        private float wallCollisionCoolDown;
        private float wallCollisionCoolDownTime = 0.75f; // thời gian di chuyển xa khỏi tường, tránh quay đầu quá nhanh

        public Enemy(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            horizontalOffset = perlinNoiseOffset;
            perlinNoiseOffset += 0.03f; // Tạo sự khác biệt cho từng kẻ địch
            horizontalSpeed = 55f; // Tốc độ di chuyển ngang
            Bullets = new List<BulletPlayer>();
            shootCoolDown = 0;
            isCollidedWithLeftWall = false;
            isCollidedWithRightWall = false;
            wallCollisionCoolDown = 0;
        }

        // Phương thức bắn đạn
        public void Shoot(Texture2D bulletTexture, float bulletSpeed)
        {
            if (shootCoolDown <= 0)
            {
                BulletPlayer bullet = new BulletPlayer(bulletTexture, new Vector2(Position.X, Position.Y), bulletSpeed);
                Bullets.Add(bullet);
                shootCoolDown = shootCoolDownTime; // Reset thời gian chờ sau khi bắn
            }
        }

        // Phương thức di chuyển ra xa khỏi tường sau khi va chạm --> tránh tình trạng kẹt lâu ở 2 mép màn hình
        public void MoveAfterCollisionWithWall(GameTime gameTime, GraphicsDeviceManager graphics, float moveValue)
        {
            // dựng cờ
            if (Position.X < 0 + Texture.Width / 2)
            {
                isCollidedWithLeftWall = true;
                wallCollisionCoolDown = wallCollisionCoolDownTime;
            }
            else if (Position.X > graphics.PreferredBackBufferWidth - Texture.Width / 2)
            {
                isCollidedWithRightWall = true;
                wallCollisionCoolDown = wallCollisionCoolDownTime;
            }
            // di chuyển
            if (wallCollisionCoolDown > 0)
            {
                if (isCollidedWithLeftWall)
                {
                    Position += new Vector2(Math.Abs(moveValue), 0);
                }
                else if (isCollidedWithRightWall)
                {
                    Position += new Vector2(-Math.Abs(moveValue), 0);
                }
                wallCollisionCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                isCollidedWithLeftWall = false;
                isCollidedWithRightWall = false;
                Position += new Vector2(moveValue, 0);
            }
        }

        // Phương thức cập nhật trạng thái của kẻ địch
        public void Update(GameTime gameTime, List<BulletPlayer> bullets, List<Enemy> enemies, GraphicsDeviceManager graphics)
        {
            // Cập nhật cooldown
            if (shootCoolDown > 0)
            {
                shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Di chuyển kẻ địch xuống
            Position += new Vector2(0, Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

            // Di chuyển ngang dựa trên Perlin noise hoặc giá trị ngẫu nhiên
            float perlinValue = MathHelper.Lerp(-1, 1, (float)SimplexNoise.Noise.CalcPixel2D((int)horizontalOffset, 0, 0.05f) / 255f);
            horizontalOffset += 0.1f; // Tăng giá trị của Perlin noise theo thời gian
            float moveValue = perlinValue * horizontalSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            MoveAfterCollisionWithWall(gameTime, graphics, moveValue);
            //Position += new Vector2(moveValue, 0);

            // Nếu kẻ địch vượt quá viền dưới màn hình (khoảng cách 50 đơn vị), xóa nó
            if (Position.Y > graphics.PreferredBackBufferHeight + 50)
            {
                enemies.Remove(this);
            }

            // Kiểm tra va chạm với đạn của người chơi
            CheckCollisionWithBullets(bullets, enemies);
        }

        // Phương thức kiểm tra va chạm với đạn
        private void CheckCollisionWithBullets(List<BulletPlayer> bullets, List<Enemy> enemies)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                BulletPlayer bullet = bullets[i];
                if (Vector2.Distance(bullet.Position, this.Position) < (this.Texture.Width / 2 + bullet.Texture.Width / 2))
                {
                    // Nếu va chạm, xóa cả đạn và kẻ địch
                    bullets.RemoveAt(i);
                    enemies.Remove(this);
                    break;
                }
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            SimplifyDrawing.HandleCentered(_spriteBatch, Texture, Position);
        }
    }
}
