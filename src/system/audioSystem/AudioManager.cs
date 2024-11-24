
using System;
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2
{
    public class AudioManager
    {
        private Song _currentSong;
        public static void Play(Song song, float volume = 1.0f, bool loop = true)
        {
            if (MediaPlayer.State != MediaState.Playing || MediaPlayer.Queue.ActiveSong != song)   //MediaPlayer.State != MediaState.Playing || MediaPlayer.Queue.ActiveSong != song
            {
                MediaPlayer.Stop();
                //_currentSong = song;
                MediaPlayer.Play(song);
                MediaPlayer.Volume = volume;
                MediaPlayer.IsRepeating = loop;
            }
        }

        public static Song GetRandomCombatTheme()
        {
            int index = new Random().Next(1, 5);
            return index switch
            {
                1 => Soundtrack.CombatTheme1,
                2 => Soundtrack.CombatTheme2,
                3 => Soundtrack.CombatTheme3,
                4 => Soundtrack.CombatTheme4,
                _ => Soundtrack.CombatTheme1,
            };
        }
    }
}