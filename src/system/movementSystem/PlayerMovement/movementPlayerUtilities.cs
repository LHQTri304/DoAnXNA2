using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public static class MovementPlayerUtilities
    {
        public static Vector2 GetNewPosition(Vector2 position, KeyboardState kstate, float speed, float elapsedTime)
        {
            Vector2 direction = Vector2.Zero;
            if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W)) direction.Y -= 1;
            if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S)) direction.Y += 1;
            if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A)) direction.X -= 1;
            if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D)) direction.X += 1;
            return position += direction * speed * elapsedTime;
        }

        public static Vector2 GetNewPosition(Vector2 position, MouseState mstate)
        {
            Vector2 mousePosition = new Vector2(mstate.X, mstate.Y);
            return mousePosition;
        }

        public static Vector2 KeepPlayerInsideWindow(GraphicsDeviceManager graphics, Vector2 position, Texture2D texture)
        {
            float windowWidth = graphics.PreferredBackBufferWidth;
            float windowHeight = graphics.PreferredBackBufferHeight;
            return new Vector2(
                MathHelper.Clamp(position.X, 0, windowWidth),
                MathHelper.Clamp(position.Y, 0 + texture.Height / 2, windowHeight - texture.Height / 2)
            );
        }
    }
}