using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class CircularMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Radius;
        private float _Angle;

        public CircularMovement(float speed, float radius)
        {
            _Speed = speed;
            _Radius = radius;
            _Angle = 0;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _Angle += _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += new Vector2((float)Math.Cos(_Angle) * _Radius, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
