using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2;

namespace DoAnXNA2
{
    public abstract class EnemySpawner
    {
        protected Vector2 _spawnPosition;
        protected Game1 _game1;

        private double _elapsedTime;
        private double _spawnInterval;
        private int _maxEnemies;

        public EnemySpawner(Game1 game)
        {
            _game1 = game;
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
            if (_elapsedTime >= _spawnInterval && _game1.AllEnemies.Count < _maxEnemies)
            {
                SpawnEnemy();
                _elapsedTime = 0; // Reset thời gian
            }
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            AutoSpawn(gameTime);
        }
    }
}
