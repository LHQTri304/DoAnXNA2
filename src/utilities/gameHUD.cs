using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DoAnXNA2.src.utilities
{
    public class GameHUD
    {
        private SpriteFont Font { get; set; }
        private TimeSpan _gameTimeElapsed;
        private int _enemyCount;
        private float _playerHealth;
        private Random _random;

        public GameHUD(SpriteFont font)
        {
            Font = font;
            _gameTimeElapsed = TimeSpan.Zero;
            _enemyCount = 0;
            _playerHealth = 100;
            _random = new Random();
        }

        // Cập nhật thời gian và thanh máu
        public void Update(GameTime gameTime, int enemyCount)
        {
            _gameTimeElapsed += gameTime.ElapsedGameTime;
            _enemyCount = enemyCount;

            // Ngẫu nhiên tăng giảm thanh máu
            _playerHealth += (float)(_random.NextDouble() * 2 - 1); // Tăng giảm ngẫu nhiên
            _playerHealth = MathHelper.Clamp(_playerHealth, 0, 100); // Giới hạn từ 0 đến 100
        }

        // Vẽ HUD
        public void Draw(SpriteBatch spriteBatch, Texture2D healthBarTexture)
        {
            // Hiển thị đồng hồ thời gian
            string timeText = $"Time: {_gameTimeElapsed.TotalSeconds:F2}";
            Textures.customFont.DrawText(spriteBatch, timeText, new Vector2(10, 10), Color.White);

            // Hiển thị số lượng kẻ địch
            string enemyText = $"Enemies: {_enemyCount}";
            spriteBatch.DrawString(Font, enemyText, new Vector2(10, 40), Color.White);

            // Hiển thị thanh máu
            int healthBarWidth = (int)(_playerHealth / 100 * 200); // Chiều rộng thanh máu dựa trên sức khỏe
            spriteBatch.Draw(healthBarTexture, new Rectangle(10, 70, healthBarWidth, 20), Color.Red);
        }
    }
}
