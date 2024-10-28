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
        public static void HandleCenteredText(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position)
        {
            // Tính toán kích thước của đoạn text
            Vector2 textSize = _spriteFont.MeasureString(_text);

            // Tính toán origin sao cho trung tâm đoạn text nằm đúng vị trí yêu cầu
            Vector2 origin = textSize / 2;

            // Vẽ đoạn text với origin ở trung tâm
            _spriteBatch.DrawString(_spriteFont, _text, _position, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0.5f);
        }
    }
}
