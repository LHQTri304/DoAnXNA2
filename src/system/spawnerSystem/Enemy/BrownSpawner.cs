using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class BrownSpawner : EnemySpawner
    {
        private Random _random;
        private float spawnPointX;
        public BrownSpawner(Game1 game)
            : base(game)
        {
            _spawnPosition = new Vector2(0, 0);
        }
        public override void SpawnEnemy()
        {
            Enemy newEnemy = EnemyFactory.CreateEnemy(_game1, "Brown", RandomSpawnPoint());
            if (newEnemy != null)
                _game1.AllEnemies.Add(newEnemy);
        }
        private Vector2 RandomSpawnPoint()
        {
            _random = new Random();
            spawnPointX = _random.Next(50, _game1.VirtualWidth - 50);
            return new Vector2(spawnPointX, -50);
        }
    }
}