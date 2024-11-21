using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class BounceMovement : IMovementStrategy
    {
        private float _SpeedX;
        private float _SpeedY;
        private bool _GoingRight;

        public BounceMovement(float speedX, float speedY)
        {
            _SpeedX = speedX;
            _SpeedY = speedY;
            _GoingRight = true;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            if (position.X <= 0 || position.X >= graphics.PreferredBackBufferWidth)
            {
                _GoingRight = !_GoingRight;
            }
            float moveX = _GoingRight ? _SpeedX : -_SpeedX;
            position += new Vector2(moveX, _SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
