using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2;
using System.Collections.Generic;

namespace DoAnXNA2.src.factoryMethod
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
