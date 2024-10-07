using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.utilities
{
    public static class SimplifyDrawing
    {
        public static void HandleCentered(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position)
        {
            _spriteBatch.Draw(
                texture, position, 
                null, 
                Color.White, 
                0f, 
                new Vector2(texture.Width / 2, texture.Height / 2), 
                1f, 
                SpriteEffects.None, 
                0f
            );
        }
    }
}
