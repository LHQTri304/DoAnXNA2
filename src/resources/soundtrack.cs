using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2
{
    public static class Soundtrack
    {
        // Background songs
        public static Song TitleTheme { get; private set; }
        public static Song BossTheme { get; private set; }
        public static Song CombatTheme1 { get; private set; }
        public static Song CombatTheme2 { get; private set; }
        public static Song CombatTheme3 { get; private set; }
        public static Song CombatTheme4 { get; private set; }
        public static Song GameOver { get; private set; }
        public static Song StageClear { get; private set; }

        // Sound Effects
        public static SoundEffect PlayerShot { get; private set; }
        public static SoundEffect EnemyShot { get; private set; }
        public static SoundEffect EnemyKilled { get; private set; }

        public static void LoadAll(ContentManager content)
        {
            // Background songs
            TitleTheme = content.Load<Song>("Title Theme CI3");
            BossTheme = content.Load<Song>("Boss Theme CI3");
            CombatTheme1 = content.Load<Song>("Combat Theme 1 CI3");
            CombatTheme2 = content.Load<Song>("Combat Theme 2 CI3");
            CombatTheme3 = content.Load<Song>("Combat Theme 3 CI3");
            CombatTheme4 = content.Load<Song>("Combat Theme 4 CI3");
            GameOver = content.Load<Song>("Game Over CI3");
            StageClear = content.Load<Song>("Stage Clear CI3");

            // Sound Effects
            PlayerShot = content.Load<SoundEffect>("Player Shot");
            EnemyShot = content.Load<SoundEffect>("Enemy Shot");
            EnemyKilled = content.Load<SoundEffect>("Enemy Killed");
        }
    }
}
