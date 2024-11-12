/* using System;
using System.Collections.Generic;
using System.Linq;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.utilities
{
    public class EnemySpawner
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        private Random _randomEnemiesSpawnX = new Random();
        private float _spawnCooldown;
        private readonly float _spawnCooldownTime;

        public EnemySpawner(float spawnCooldownTime)
        {
            _spawnCooldownTime = spawnCooldownTime;
        }

        // Phương thức cập nhật để spawn kẻ địch theo thời gian
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, Texture2D enemyTexture, List<BulletPlayer> bullets, Texture2D bulletTexture, float bulletSpeed)
        {
            // Cập nhật trạng thái kẻ địch hiện tại
            Enemies = Enemies.Where(enemy =>
            {
                enemy.Update(gameTime, graphics, bullets, Enemies, bulletTexture, bulletSpeed);
                return enemy.IsAlive; // Giữ lại kẻ địch còn sống
            }).ToList();

            // Giảm cooldown
            _spawnCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Spawn kẻ địch mới nếu cooldown <= 0
            if (_spawnCooldown <= 0)
            {
                SpawnEnemy(enemyTexture, graphics);
                _spawnCooldown = _spawnCooldownTime; // Reset cooldown
            }
        }

        private void SpawnEnemy(Texture2D enemyTexture, GraphicsDeviceManager graphics)
        {
            // Sinh vị trí x ngẫu nhiên trong phạm vi chiều ngang khung hình
            float randomX = _randomEnemiesSpawnX.Next(0, graphics.PreferredBackBufferWidth);

            // Tạo kẻ địch mới ở vị trí (randomX, -10) với tốc độ di chuyển dọc 10f
            var newEnemy = new Enemy(enemyTexture, new Vector2(randomX, -10), 10f);

            // Thêm kẻ địch vào danh sách
            Enemies.Add(newEnemy);
        }

        public void ClearEnemies()
        {
            Enemies.Clear();
        }
    }
}
 */

using System.Collections.Generic;
using System.Linq;
using DoAnXNA2.src.factoryMethod;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.spawners
{
    public class EnemySpawner
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        private Vector2 spawnPosition;

        public EnemySpawner(Vector2 spawnPosition)
        {
            Enemies = new List<Enemy>();
            this.spawnPosition = spawnPosition;
        }

        public void SpawnEnemy(string type)
        {
            Enemy newEnemy = EnemyFactory.CreateEnemy(type, spawnPosition);
            if (newEnemy != null)
            {
                Enemies.Add(newEnemy);
            }
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, List<BulletPlayer> bullets)
        {
            Enemies = Enemies.Where(enemy =>
            {
                enemy.Update(gameTime, graphics, bullets);
                return enemy.IsAlive; // Giữ lại kẻ địch còn sống
            }).ToList();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}