using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class WaveMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Amplitude;
        private float _WaveLength;
        private float _Offset;

        public WaveMovement(float speed, float amplitude, float waveLength, float offset)
        {
            _Speed = speed;
            _Amplitude = amplitude;
            _WaveLength = waveLength;
            _Offset = offset;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _Offset += _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float offsetX = (float)Math.Cos(position.Y / _WaveLength) * _Amplitude;
            position += new Vector2(offsetX, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
