using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class BulletEnemy : Bullet
    {
        public BulletEnemy(Vector2 position, float speed, float rotate)
            : base(Textures.BulletE, position, speed, rotate + 180) { }
    }
}