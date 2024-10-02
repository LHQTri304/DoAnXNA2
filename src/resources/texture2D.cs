using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class Textures
    {
        public static Texture2D texturePlayer;
        public static Texture2D textureBulletP;

        // For HUD
        private static Texture2D fontTexture;
        public static CustomBitmapFont customFont;


        public static void LoadTextures(ContentManager content)
        {
            texturePlayer = content.Load<Texture2D>("player");
            textureBulletP = content.Load<Texture2D>("bulletPlayer");

            // Load font texture từ file hình ảnh
            fontTexture = content.Load<Texture2D>("SpriteFontTestSubject3");
            customFont = new CustomBitmapFont(fontTexture);
        }
    }
}
