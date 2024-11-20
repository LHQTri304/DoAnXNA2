using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class EmptySpawner : EnemySpawner
    {
        public EmptySpawner(Game1 game)
            : base(game)
        {
            _spawnPosition = new Vector2(0, 0);
        }
        public override void SpawnEnemy()
        {
            return;
        }
    }
}