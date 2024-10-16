using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.utilities;

namespace DoAnXNA2.src.sprites
{
    public class BulletPlayer
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public BulletPlayer(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
        }

        public void Move()
        {
            Position = new Vector2(Position.X, Position.Y - Speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SimplifyDrawing.HandleCentered(spriteBatch, Texture, Position);
        }
    }
}
