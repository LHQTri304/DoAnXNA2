using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class Textures
    {
        //Player
        public static Texture2D Player { get; private set; }
        public static Texture2D BulletP { get; private set; }

        //Enemies
        public static Texture2D EnemyYellow { get; private set; }
        public static Texture2D EnemyRed { get; private set; }
        public static Texture2D EnemyGreen { get; private set; }
        public static Texture2D EnemyBlue { get; private set; }
        public static Texture2D BulletE { get; private set; }

        // For UI
        public static List<Texture2D> BackgroundStuff { get; private set; }
        public static Texture2D Cursor { get; private set; }

        //Button
        public static Texture2D StartButton { get; private set; }
        public static Texture2D ReturnButton { get; private set; }


        public static void LoadAll(ContentManager content)
        {
            //Player
            Player = content.Load<Texture2D>("Space Fighter");
            BulletP = content.Load<Texture2D>("Fire Blaster");

            //Enemies
            EnemyYellow = content.Load<Texture2D>("enemyYellow");
            EnemyRed = content.Load<Texture2D>("enemyRed");
            EnemyGreen = content.Load<Texture2D>("enemyGreen");
            EnemyBlue = content.Load<Texture2D>("enemyBlue");
            BulletE = content.Load<Texture2D>("Mini Galaxy");

            //UI            
            BackgroundStuff = [
                content.Load<Texture2D>("Infinite Space Background"),
                content.Load<Texture2D>("Astronaut"),
                content.Load<Texture2D>("Black Hole"),
                content.Load<Texture2D>("Full Moon"),
                content.Load<Texture2D>("Jupiter Planet"),
                content.Load<Texture2D>("Mars Planet"),
                content.Load<Texture2D>("Mercury Planet"),
                content.Load<Texture2D>("Neptune Planet"),
                content.Load<Texture2D>("Planet"),
                content.Load<Texture2D>("Pluto Dwarf Planet"),
                content.Load<Texture2D>("Saturn Planet"),
                content.Load<Texture2D>("Uranus Planet"),
                content.Load<Texture2D>("enemyYellow"),
                content.Load<Texture2D>("enemyRed"),
                content.Load<Texture2D>("enemyGreen"),
                content.Load<Texture2D>("enemyBlue"),
                content.Load<Texture2D>("Mini Galaxy"),
                content.Load<Texture2D>("Space Fighter"),
            ];
            Cursor = content.Load<Texture2D>("Cursor");

            //Button
            StartButton = content.Load<Texture2D>("enemyYellow");
            ReturnButton = content.Load<Texture2D>("enemyYellow");

        }
    }
}
