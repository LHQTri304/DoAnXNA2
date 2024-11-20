using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class BulletEnemy : Bullet
    {
        public BulletEnemy(Vector2 position, float speed, float rotate)
            : base(Textures.BulletE, position, DMGStatsManager.BulletEnemyDMG, speed, rotate + 180) { }
    }
}