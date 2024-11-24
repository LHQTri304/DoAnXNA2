using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class RedSpawner : EnemySpawner
    {
        private Random _random;
        private float spawnPointX;
        public RedSpawner()
            : base()
        {
            _spawnPosition = new Vector2(0, 0);
        }
        public override void SpawnEnemy()
        {
            Enemy newEnemy = EnemyFactory.CreateEnemy("Red", RandomSpawnPoint());
            if (newEnemy != null)
                MainRes.AllEnemies.Add(newEnemy);
        }
        private Vector2 RandomSpawnPoint()
        {
            _random = new Random();
            spawnPointX = _random.Next(50, MainRes.ScreenWidth - 50);
            return new Vector2(spawnPointX, -50);
        }
    }
}