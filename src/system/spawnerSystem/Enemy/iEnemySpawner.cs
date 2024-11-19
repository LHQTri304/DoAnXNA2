using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2;

namespace DoAnXNA2
{
    public abstract class EnemySpawner
    {
        public List<Enemy> Enemies { get; set; }
        protected Vector2 _spawnPosition;
        protected Game1 _game;

        private double _elapsedTime;
        private double _spawnInterval;
        private int _maxEnemies;

        public EnemySpawner(Game1 game)
        {
            _game = game;
            Enemies = [];
            _elapsedTime = 0;
        }

        public abstract void SpawnEnemy();

        public void StartAutoSpawn(double spawnInterval, int maxEnemies)
        {
            _spawnInterval = spawnInterval;
            _maxEnemies = maxEnemies;
        }

        private void AutoSpawn(GameTime gameTime)
        {
            // Tăng thời gian trôi qua
            _elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            // Nếu đủ thời gian và số lượng kẻ địch chưa đạt max
            if (_elapsedTime >= _spawnInterval && Enemies.Count < _maxEnemies)
            {
                SpawnEnemy();
                _elapsedTime = 0; // Reset thời gian
            }
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Enemies = Enemies.Where(enemy =>
            {
                enemy.Update(gameTime, graphics);
                return enemy.IsAlive; // Giữ lại kẻ địch còn sống
            }).ToList();

            // Gọi AutoSpawn
            AutoSpawn(gameTime);
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
