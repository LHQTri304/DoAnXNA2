using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.utilities;

namespace DoAnXNA2.src.sprites
{
    public class BulletEnemy
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }
        public float Speed { get; private set; }

        public BulletEnemy(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
        }

        public void Move()
        {
            Position = new Vector2(Position.X, Position.Y + Speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}
