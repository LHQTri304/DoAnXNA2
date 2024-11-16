using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class Textures
    {
        //Player
        public static Texture2D texturePlayer;
        public static Texture2D textureBulletP;

        //Enemies
        public static Texture2D textureEnemyYellow;
        public static Texture2D textureEnemyRed;
        public static Texture2D textureEnemyGreen;
        public static Texture2D textureEnemyBlue;
        public static Texture2D textureBulletE;

        // For HUD
        private static Texture2D fontTexture;
        public static CustomBitmapFont customFont;
        public static Texture2D textureHP;

        //Button
        public static Texture2D startButton;
        public static Texture2D returnButton;


        public static void LoadTextures(ContentManager content)
        {
            //Player
            texturePlayer = content.Load<Texture2D>("Space Fighter");
            textureBulletP = content.Load<Texture2D>("Fire Blaster");

            //Enemies
            textureEnemyYellow = content.Load<Texture2D>("enemyYellow");
            textureEnemyRed = content.Load<Texture2D>("enemyRed");
            textureEnemyGreen = content.Load<Texture2D>("enemyGreen");
            textureEnemyBlue = content.Load<Texture2D>("enemyBlue");
            textureBulletE = content.Load<Texture2D>("Mini Galaxy");

            //GUI            
            textureHP = content.Load<Texture2D>("TestHP");
            fontTexture = content.Load<Texture2D>("SpriteFontTestSubject3");
            customFont = new CustomBitmapFont(fontTexture);

            //Button
            startButton = content.Load<Texture2D>("enemyYellow");
            returnButton = content.Load<Texture2D>("enemyYellow");

        }
    }
}
