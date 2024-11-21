using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SlowStopMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Friction;

        public SlowStopMovement(float speed = 100f, float friction = 6.6f)
        {
            _Speed = speed;
            _Friction = friction;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _Speed = Math.Max(0, _Speed - _Friction * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position += new Vector2(0, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
