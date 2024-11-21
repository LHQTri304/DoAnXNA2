using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class GravityFallMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Gravity;

        public GravityFallMovement(float initialSpeed, float gravity)
        {
            _Speed = initialSpeed;
            _Gravity = gravity;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _Speed += _Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += new Vector2(0, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
