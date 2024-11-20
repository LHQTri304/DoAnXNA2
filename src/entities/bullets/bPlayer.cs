using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class BulletPlayer : Bullet
    {
        public BulletPlayer(Vector2 position, float speed, float rotate)
            : base(Textures.BulletP, position, DMGStatsManager.BulletPlayerDMG, speed, rotate) { }
    }
}