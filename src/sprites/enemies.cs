// enemies.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using DoAnXNA2.src.utilities;

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

        public Enemy(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            horizontalOffset = perlinNoiseOffset;
            perlinNoiseOffset += 0.1f; // Tạo sự khác biệt cho từng kẻ địch
            horizontalSpeed = 50f; // Tốc độ di chuyển ngang, có thể tùy chỉnh
        }

        // Phương thức cập nhật vị trí của kẻ địch
        public void Update(GameTime gameTime, List<BulletPlayer> bullets, List<Enemy> enemies, GraphicsDeviceManager graphics)
        {
            // Di chuyển kẻ địch xuống
            Position += new Vector2(0, Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

            // Di chuyển ngang dựa trên Perlin noise hoặc giá trị ngẫu nhiên
            float perlinValue = MathHelper.Lerp(-1, 1, (float)SimplexNoise.Noise.CalcPixel2D((int)horizontalOffset, 0, 0.05f) / 255f);
            horizontalOffset += 0.1f; // Tăng giá trị của Perlin noise theo thời gian
            Position += new Vector2(perlinValue * horizontalSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);

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
