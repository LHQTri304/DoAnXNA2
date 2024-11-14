using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.sprites
{
    public class BulletEnemy : Bullet
    {
        public BulletEnemy(Texture2D texture, Vector2 position, float speed, float rotate)
            : base(texture, position, speed, rotate + 180) { }
    }
}