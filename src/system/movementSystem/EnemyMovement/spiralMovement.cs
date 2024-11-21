using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SpiralMovement : IMovementStrategy
    {
        private float _Speed;   // Tốc độ di chuyển xuống
        private float _Radius;  // Bán kính
        private float _Angle;   // Góc ban đầu

        public SpiralMovement(float speed = 50f, float radius = 2f)
        {
            _Speed = speed;
            _Radius = radius;
            _Angle = 0;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _Angle += _Speed * (float)gameTime.ElapsedGameTime.TotalMinutes;
            position += new Vector2((float)Math.Cos(_Angle) * _Radius, (float)Math.Sin(_Angle) * _Radius + _Speed * (float)gameTime.ElapsedGameTime.TotalMinutes);
            _Radius -= _Speed * (float)gameTime.ElapsedGameTime.TotalMinutes; // Giảm dần bán kính
            return position;
        }
    }

}
