using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public void Move(KeyboardState kstate, float updatedBulletPlayerSpeed)
        {
            Vector2 newPosition = Position;
            newPosition.Y -= Speed;
            Position = newPosition;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            SimplifyDrawing.HandleCentered(_spriteBatch, Texture, Position);
        }
    }
}