using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class AcceleratingMovement : IMovementStrategy
    {
        private float _InitialSpeed;
        private float _Acceleration;

        public AcceleratingMovement(float initialSpeed, float acceleration)
        {
            _InitialSpeed = initialSpeed;
            _Acceleration = acceleration;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _InitialSpeed += _Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += new Vector2(0, _InitialSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
