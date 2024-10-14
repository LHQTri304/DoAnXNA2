using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class Textures
    {
        public static Texture2D texturePlayer;
        public static Texture2D textureBulletP;
        public static Texture2D textureEnemy;
        public static Texture2D textureBulletE;

        // For HUD
        private static Texture2D fontTexture;
        public static CustomBitmapFont customFont;
        public static Texture2D textureHP;


        public static void LoadTextures(ContentManager content)
        {
            texturePlayer = content.Load<Texture2D>("player");
            textureBulletP = content.Load<Texture2D>("bulletPlayer");
            textureEnemy = content.Load<Texture2D>("enemyYellow");
            textureBulletE = content.Load<Texture2D>("bulletEnemy");

            //GUI            
            textureHP = content.Load<Texture2D>("TestHP");
            fontTexture = content.Load<Texture2D>("SpriteFontTestSubject3");
            customFont = new CustomBitmapFont(fontTexture);
        }
    }
}
