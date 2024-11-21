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
        public static Texture2D EnemyOrange { get; private set; }
        public static Texture2D EnemyPurple { get; private set; }
        public static Texture2D EnemyGray { get; private set; }
        public static Texture2D EnemyCyan { get; private set; }
        public static Texture2D EnemyLime { get; private set; }
        public static Texture2D EnemyPink { get; private set; }
        public static Texture2D EnemyBrown { get; private set; }
        public static Texture2D EnemyTeal { get; private set; }
        public static Texture2D EnemyBlack { get; private set; }
        public static Texture2D EnemyWhite { get; private set; }
        public static Texture2D EnemyGold { get; private set; }
        public static Texture2D EnemySilver { get; private set; }
        public static Texture2D EnemyMaroon { get; private set; }
        public static Texture2D EnemyNavy { get; private set; }
        public static Texture2D BulletE { get; private set; }

        // For UI
        public static List<Texture2D> BackgroundStuff { get; private set; }
        public static Texture2D Cursor { get; private set; }
        public static Texture2D TitleGame { get; private set; }

        // Buttons
        public static Texture2D Backward_BTN { get; private set; }
        public static Texture2D Backward_BTN_Active { get; private set; }
        public static Texture2D Blank_BTN { get; private set; }
        public static Texture2D Blank_BTN_Active { get; private set; }
        public static Texture2D Close_BTN { get; private set; }
        public static Texture2D Close_BTN_Active { get; private set; }
        public static Texture2D Replay_BTN { get; private set; }
        public static Texture2D Replay_BTN_Active { get; private set; }
        public static Texture2D Settings_BTN { get; private set; }
        public static Texture2D Settings_BTN_Active { get; private set; }
        public static Texture2D Facebook_BTN { get; private set; }
        public static Texture2D Facebook_BTN_Active { get; private set; }
        public static Texture2D Shop_BTN { get; private set; }
        public static Texture2D Shop_BTN_Active { get; private set; }
        public static Texture2D FAQ_BTN { get; private set; }
        public static Texture2D FAQ_BTN_Active { get; private set; }
        public static Texture2D Forward_BTN { get; private set; }
        public static Texture2D Forward_BTN_Active { get; private set; }
        public static Texture2D Sound_BTN { get; private set; }
        public static Texture2D Sound_BTN_Active { get; private set; }
        public static Texture2D Twitter_BTN { get; private set; }
        public static Texture2D Twitter_BTN_Active { get; private set; }
        public static Texture2D Google_BTN { get; private set; }
        public static Texture2D Google_BTN_Active { get; private set; }
        public static Texture2D Upgrade_BTN { get; private set; }
        public static Texture2D Upgrade_BTN_Active { get; private set; }
        public static Texture2D Vibration_BTN { get; private set; }
        public static Texture2D Vibration_BTN_Active { get; private set; }
        public static Texture2D VK_BTN { get; private set; }
        public static Texture2D VK_BTN_Active { get; private set; }
        public static Texture2D Hangar_BTN { get; private set; }
        public static Texture2D Hangar_BTN_Active { get; private set; }
        public static Texture2D Info_BTN { get; private set; }
        public static Texture2D Info_BTN_Active { get; private set; }
        public static Texture2D Menu_BTN { get; private set; }
        public static Texture2D Menu_BTN_Active { get; private set; }
        public static Texture2D More_Games_BTN { get; private set; }
        public static Texture2D More_Games_BTN_Active { get; private set; }
        public static Texture2D Music_BTN { get; private set; }
        public static Texture2D Music_BTN_Active { get; private set; }
        public static Texture2D Notifications_BTN { get; private set; }
        public static Texture2D Notifications_BTN_Active { get; private set; }
        public static Texture2D Ok_BTN { get; private set; }
        public static Texture2D Ok_BTN_Active { get; private set; }
        public static Texture2D Pause_BTN { get; private set; }
        public static Texture2D Pause_BTN_Active { get; private set; }
        public static Texture2D Play_BTN { get; private set; }
        public static Texture2D Play_BTN_Active { get; private set; }
        public static Texture2D Rating_BTN { get; private set; }
        public static Texture2D Rating_BTN_Active { get; private set; }


        public static void LoadAll(ContentManager content)
        {
            //Player
            Player = content.Load<Texture2D>("Space Fighter");
            BulletP = content.Load<Texture2D>("Fire Blaster");

            //Enemies
            EnemyYellow = content.Load<Texture2D>("Reman Warbird Scimitar");
            EnemyRed = content.Load<Texture2D>("Gquan Class Heavy Cruiser");
            EnemyGreen = content.Load<Texture2D>("Star Trek Romulan Ship");
            EnemyBlue = content.Load<Texture2D>("Sharlin Class Warcruiser");
            EnemyOrange = content.Load<Texture2D>("Babylon 5 Centauri Ship Orange");
            EnemyPurple = content.Load<Texture2D>("Babylon 5 Interstellar Alliance Ship");
            EnemyGray = content.Load<Texture2D>("Romulan Warbird Valdore");
            EnemyCyan = content.Load<Texture2D>("Jem Hadar Battlecruiser");
            EnemyLime = content.Load<Texture2D>("Upsilon-class Command Shuttle");
            EnemyPink = content.Load<Texture2D>("Star Trek Kumari Ship");
            EnemyBrown = content.Load<Texture2D>("Star Trek Vulcans Ship");
            EnemyTeal = content.Load<Texture2D>("Tie Fighter");
            EnemyBlack = content.Load<Texture2D>("Star Wars Rebellion Ship");
            EnemyWhite = content.Load<Texture2D>("Deep Space 9");
            EnemyGold = content.Load<Texture2D>("Species 8472 Bioship");
            EnemySilver = content.Load<Texture2D>("Spacedock");
            EnemyMaroon = content.Load<Texture2D>("Babylon 5 Federal Ship");
            EnemyNavy = content.Load<Texture2D>("Star Trek Deep Space Nine");
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
            TitleGame = content.Load<Texture2D>("Title Game");

            // Buttons
            Backward_BTN = content.Load<Texture2D>("Backward_BTN");
            Backward_BTN_Active = content.Load<Texture2D>("Backward_BTN_Active");
            Blank_BTN = content.Load<Texture2D>("Blank_BTN");
            Blank_BTN_Active = content.Load<Texture2D>("Blank_BTN_Active");
            Close_BTN = content.Load<Texture2D>("Close_BTN");
            Close_BTN_Active = content.Load<Texture2D>("Close_BTN_Active");
            Replay_BTN = content.Load<Texture2D>("Replay_BTN");
            Replay_BTN_Active = content.Load<Texture2D>("Replay_BTN_Active");
            Settings_BTN = content.Load<Texture2D>("Settings_BTN");
            Settings_BTN_Active = content.Load<Texture2D>("Settings_BTN_Active");
            Facebook_BTN = content.Load<Texture2D>("Facebook_BTN");
            Facebook_BTN_Active = content.Load<Texture2D>("Facebook_BTN_Active");
            Shop_BTN = content.Load<Texture2D>("Shop_BTN");
            Shop_BTN_Active = content.Load<Texture2D>("Shop_BTN_Active");
            FAQ_BTN = content.Load<Texture2D>("FAQ_BTN");
            FAQ_BTN_Active = content.Load<Texture2D>("FAQ_BTN_Active");
            Forward_BTN = content.Load<Texture2D>("Forward_BTN");
            Forward_BTN_Active = content.Load<Texture2D>("Forward_BTN_Active");
            Sound_BTN = content.Load<Texture2D>("Sound_BTN");
            Sound_BTN_Active = content.Load<Texture2D>("Sound_BTN_Active");
            Twitter_BTN = content.Load<Texture2D>("Twitter_BTN");
            Twitter_BTN_Active = content.Load<Texture2D>("Twitter_BTN_Active");
            Google_BTN = content.Load<Texture2D>("Google_BTN");
            Google_BTN_Active = content.Load<Texture2D>("Google_BTN_Active");
            Upgrade_BTN = content.Load<Texture2D>("Upgrade_BTN");
            Upgrade_BTN_Active = content.Load<Texture2D>("Upgrade_BTN_Active");
            Vibration_BTN = content.Load<Texture2D>("Vibration_BTN");
            Vibration_BTN_Active = content.Load<Texture2D>("Vibration_BTN_Active");
            VK_BTN = content.Load<Texture2D>("VK_BTN");
            VK_BTN_Active = content.Load<Texture2D>("VK_BTN_Active");
            Hangar_BTN = content.Load<Texture2D>("Hangar_BTN");
            Hangar_BTN_Active = content.Load<Texture2D>("Hangar_BTN_Active");
            Info_BTN = content.Load<Texture2D>("Info_BTN");
            Info_BTN_Active = content.Load<Texture2D>("Info_BTN_Active");
            Menu_BTN = content.Load<Texture2D>("Menu_BTN");
            Menu_BTN_Active = content.Load<Texture2D>("Menu_BTN_Active");
            More_Games_BTN = content.Load<Texture2D>("More_Games_BTN");
            More_Games_BTN_Active = content.Load<Texture2D>("More_Games_BTN_Active");
            Music_BTN = content.Load<Texture2D>("Music_BTN");
            Music_BTN_Active = content.Load<Texture2D>("Music_BTN_Active");
            Notifications_BTN = content.Load<Texture2D>("Notifications_BTN");
            Notifications_BTN_Active = content.Load<Texture2D>("Notifications_BTN_Active");
            Ok_BTN = content.Load<Texture2D>("Ok_BTN");
            Ok_BTN_Active = content.Load<Texture2D>("Ok_BTN_Active");
            Pause_BTN = content.Load<Texture2D>("Pause_BTN");
            Pause_BTN_Active = content.Load<Texture2D>("Pause_BTN_Active");
            Play_BTN = content.Load<Texture2D>("Play_BTN");
            Play_BTN_Active = content.Load<Texture2D>("Play_BTN_Active");
            Rating_BTN = content.Load<Texture2D>("Rating_BTN");
            Rating_BTN_Active = content.Load<Texture2D>("Rating_BTN_Active");
        }
    }
}
