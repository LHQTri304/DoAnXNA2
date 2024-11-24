using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class EmptySpawner : EnemySpawner
    {
        public EmptySpawner()
            : base()
        {
            _spawnPosition = new Vector2(0, 0);
        }
        public override void SpawnEnemy()
        {
            return;
        }
    }
}