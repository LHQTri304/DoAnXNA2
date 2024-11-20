using System;
using Microsoft.Xna.Framework;
using DoAnXNA2.src.factoryMethod;
using DoAnXNA2;

namespace DoAnXNA2
{
    public class YellowSpawner : EnemySpawner
    {
        private Random _random;
        private float spawnPointX;
        public YellowSpawner(Game1 game)
            : base(game)
        {
            _spawnPosition = new Vector2(0, 0);
        }
        public override void SpawnEnemy()
        {
            Enemy newEnemy = EnemyFactory.CreateEnemy(_game1, "Yellow", RandomSpawnPoint());
            if (newEnemy != null)
                _game1._allEnemies.Add(newEnemy);
        }
        private Vector2 RandomSpawnPoint()
        {
            _random = new Random();
            spawnPointX = _random.Next(50, _game1.virtualWidth * 2);
            return new Vector2(spawnPointX, -50);
        }
    }
}