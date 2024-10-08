using System;
using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.utilities
{
    public class EnemySpawner
    {
        private List<Enemy> _enemies;
        private Random _randomEnemiesSpawnX;
        private float _spawnCooldown;
        private float _spawnCooldownTime;

        public EnemySpawner(float spawnCooldownTime)
        {
            _enemies = new List<Enemy>();
            _randomEnemiesSpawnX = new Random();
            _spawnCooldownTime = spawnCooldownTime;
            _spawnCooldown = 0;
        }

        public List<Enemy> Enemies => _enemies;

        // Phương thức cập nhật để spawn kẻ địch theo thời gian
        public void Update(GameTime gameTime, Texture2D enemyTexture, GraphicsDeviceManager graphics)
        {
            if (_spawnCooldown > 0)
            {
                _spawnCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                SpawnEnemy(enemyTexture, graphics);
                _spawnCooldown = _spawnCooldownTime; // Reset cooldown
            }
        }

        private void SpawnEnemy(Texture2D enemyTexture, GraphicsDeviceManager graphics)
        {
            // Sinh vị trí x ngẫu nhiên trong phạm vi chiều ngang khung hình
            float randomX = _randomEnemiesSpawnX.Next(0, graphics.PreferredBackBufferWidth);

            // Tạo kẻ địch mới ở vị trí (randomX, -50) với tốc độ di chuyển dọc 100f
            Vector2 enemyPosition = new Vector2(randomX, -50);
            Enemy newEnemy = new Enemy(enemyTexture, enemyPosition, 100f);

            // Thêm kẻ địch vào danh sách
            _enemies.Add(newEnemy);
        }

        public void ClearEnemies()
        {
            _enemies.Clear();
        }
    }
}
