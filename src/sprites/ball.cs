using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.sprites
{
    public class Ball
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }

        public Ball(Texture2D texture, Vector2 position, float speed)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
        }

        public void ResetPosition(GraphicsDeviceManager graphics)
        {
            float windowWidth = graphics.PreferredBackBufferWidth;
            float windowHeight = graphics.PreferredBackBufferHeight;
            Position = new Vector2(windowWidth / 2, windowHeight / 2);
        }

        public void Move(KeyboardState kstate, float updatedBallSpeed)
        {
            // Tạo biến tạm để thay đổi giá trị của Position
            Vector2 newPosition = Position;

            if (kstate.IsKeyDown(Keys.Up))
                newPosition.Y -= updatedBallSpeed;
            if (kstate.IsKeyDown(Keys.Down))
                newPosition.Y += updatedBallSpeed;
            if (kstate.IsKeyDown(Keys.Left))
                newPosition.X -= updatedBallSpeed;
            if (kstate.IsKeyDown(Keys.Right))
                newPosition.X += updatedBallSpeed;

            // Gán lại giá trị sau khi cập nhật
            Position = newPosition;
        }
    }
}