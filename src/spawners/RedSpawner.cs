using System;
using Microsoft.Xna.Framework;
using DoAnXNA2.src.factoryMethod;
using DoAnXNA2.src.sprites;

namespace DoAnXNA2.src.spawners
{
    public class RedSpawner : EnemySpawner
    {
        private Random _random;
        private float spawnPointX;
        public RedSpawner(Game1 game)
            : base(game)
        {
            _spawnPosition = new Vector2(0, 0);
        }
        public override void SpawnEnemy()
        {
            Enemy newEnemy = EnemyFactory.CreateEnemy(_game, "Red", RandomSpawnPoint());
            if (newEnemy != null)
                Enemies.Add(newEnemy);
        }
        private Vector2 RandomSpawnPoint()
        {
            _random = new Random();
            spawnPointX = _random.Next(50, _game.virtualWidth - 50);
            return new Vector2(spawnPointX, 50);
        }
    }
}