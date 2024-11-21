using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class HoverMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Amplitude;
        private float _Frequency;

        public HoverMovement(float speed, float amplitude, float frequency)
        {
            _Speed = speed;
            _Amplitude = amplitude;
            _Frequency = frequency;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            position += new Vector2(0, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.Y += (float)Math.Sin(position.X * _Frequency) * _Amplitude;
            return position;
        }
    }

}
