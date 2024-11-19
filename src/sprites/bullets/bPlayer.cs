using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.sprites
{
    public class BulletPlayer : Bullet
    {
        public BulletPlayer(Vector2 position, float speed, float rotate)
            : base(Textures.BulletP, position, speed, rotate) { }
    }
}