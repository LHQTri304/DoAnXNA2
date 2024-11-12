using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.sprites
{
    public class BulletEnemy : Bullet
    {
        public BulletEnemy(Texture2D texture, Vector2 position, float speed)
            : base(texture, position, speed) { }

        public override void Move()
        {
            Position = new Vector2(Position.X, Position.Y + Speed);
        }
    }
}