using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.utilities;
using System;

namespace DoAnXNA2.src.sprites
{
    public abstract class Bullet
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public float Rotate { get; set; } // 0 = Hướng lên | 180 = hướng xuống

        public Bullet(Texture2D texture, Vector2 position, float speed, float rotate)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            Rotate = MathHelper.ToRadians(rotate - 90);
        }

        public void Move()  //Update()
        {
            var direction = new Vector2((float)Math.Cos(Rotate), (float)Math.Sin(Rotate));
            Position += direction * Speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}
