using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class MeteoriteMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Amplitude;
        private float _Frequency;
        private float _Time;

        public MeteoriteMovement(float speed = 75f, float amplitude = 5f, float frequency = 0.1f)
        {
            _Speed = speed;
            _Amplitude = amplitude;
            _Frequency = frequency;
            _Time = 0;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            float offsetX = (float)Math.Sin(_Time * _Frequency) * _Amplitude;
            position += new Vector2(offsetX, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }
}
