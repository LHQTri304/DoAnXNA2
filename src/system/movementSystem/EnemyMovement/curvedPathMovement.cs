using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class CurvedPathMovement : IMovementStrategy
    {
        private float _Speed;
        private float _Curvature;

        public CurvedPathMovement(float speed = 100f, float curvature = 0.01f)
        {
            _Speed = speed;
            _Curvature = curvature;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            position += new Vector2((float)Math.Sin(position.Y * _Curvature), _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
