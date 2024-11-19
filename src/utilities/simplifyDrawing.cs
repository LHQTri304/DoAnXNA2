using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class SimplifyDrawing
    {
        #region Handle Draw Base On Origin
        private static void DrawBaseOnOrigin(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position, Vector2 origin)
        {
            _spriteBatch.Draw(texture, position,
                null, Color.White, 0f,
                origin,
                1f, SpriteEffects.None, 0f
            );
        }
        public static void HandleCentered(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position)
        {
            DrawBaseOnOrigin(_spriteBatch, texture, position, new Vector2(texture.Width / 2, texture.Height / 2));
        }

        public static void HandleTopLeft(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position)
        {
            DrawBaseOnOrigin(_spriteBatch, texture, position, Vector2.Zero);
        }

        public static void HandleTopRight(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position)
        {
            DrawBaseOnOrigin(_spriteBatch, texture, position, new Vector2(texture.Width, 0));
        }

        public static void HandleBottomLeft(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position)
        {
            DrawBaseOnOrigin(_spriteBatch, texture, position, new Vector2(0, texture.Height));
        }

        public static void HandleBottomRight(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position)
        {
            DrawBaseOnOrigin(_spriteBatch, texture, position, new Vector2(texture.Width, texture.Height));
        }
        #endregion

        #region Handle DrawString(Text) Base On Origin
        private static void DrawStringBaseOnOrigin(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position, Vector2 _origin)
        {
            _spriteBatch.DrawString(_spriteFont, _text, _position,
                Color.White, 0f,
                _origin,
                1.0f, SpriteEffects.None, 0.5f
            );
        }

        public static void HandleCenteredText(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position)
        {
            Vector2 textSize = _spriteFont.MeasureString(_text);
            DrawStringBaseOnOrigin(_spriteBatch, _spriteFont, _text, _position, textSize / 2);
        }

        public static void HandleTopLeftText(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position)
        {
            DrawStringBaseOnOrigin(_spriteBatch, _spriteFont, _text, _position, Vector2.Zero);
        }

        public static void HandleTopRightText(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position)
        {
            Vector2 textSize = _spriteFont.MeasureString(_text);
            DrawStringBaseOnOrigin(_spriteBatch, _spriteFont, _text, _position, new Vector2(textSize.X, 0));
        }

        public static void HandleBottomLeftText(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position)
        {
            Vector2 textSize = _spriteFont.MeasureString(_text);
            DrawStringBaseOnOrigin(_spriteBatch, _spriteFont, _text, _position, new Vector2(0, textSize.Y));
        }

        public static void HandleBottomRightText(SpriteBatch _spriteBatch, SpriteFont _spriteFont, string _text, Vector2 _position)
        {
            Vector2 textSize = _spriteFont.MeasureString(_text);
            DrawStringBaseOnOrigin(_spriteBatch, _spriteFont, _text, _position, new Vector2(textSize.X, textSize.Y));
        }
        #endregion

        #region Handle Draw Rotating Texture
        // Từ điển lưu trữ góc xoay cho từng texture
        private static Dictionary<Texture2D, float> rotationAngles = [];

        public static void HandleRotatingTexture(SpriteBatch _spriteBatch, Texture2D texture, Vector2 position, float rotationSpeed, float scale = 1f, bool clockwise = true, float layerDepth = 0f)
        {
            // Nếu texture chưa được theo dõi, khởi tạo góc xoay ban đầu là 0
            if (!rotationAngles.ContainsKey(texture))
                rotationAngles[texture] = 0f;

            // Cập nhật góc xoay (theo chiều kim đồng hồ)
            rotationAngles[texture] += clockwise ? rotationSpeed : -rotationSpeed;

            // Đảm bảo góc xoay nằm trong khoảng [0, 2 * Math.PI] để tránh tràn số
            if (rotationAngles[texture] >= MathHelper.TwoPi)
                rotationAngles[texture] -= MathHelper.TwoPi;

            // Vẽ texture với góc xoay hiện tại
            _spriteBatch.Draw(
                texture,
                position,
                null,
                Color.White,
                rotationAngles[texture], // Góc xoay
                new Vector2(texture.Width / 2, texture.Height / 2), // Origin là tâm texture
                scale,
                SpriteEffects.None,
                layerDepth
            );
        }
        #endregion
    }
}
