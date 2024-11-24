
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2
{
    public class AudioManager
    {
        private Song _currentSong;
        public void Play(Song song)
        {
            if (_currentSong != song)
            {
                MediaPlayer.Stop();
                _currentSong = song;
                MediaPlayer.Play(_currentSong);
            }
        }
    }
}