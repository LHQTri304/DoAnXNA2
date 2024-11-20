using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public static class BulletFactory
    {
        public static Bullet CreateBullet(string type, Vector2 position, float speed, float rotateAngle)
        {
            return type switch
            {
                "Player" => new BulletPlayer(position, speed, rotateAngle),
                "Enemy" => new BulletEnemy(position, speed, rotateAngle),
                _ => null
            };
        }
    }
}
