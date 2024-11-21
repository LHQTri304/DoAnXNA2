using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class RandomJitterMovement : IMovementStrategy
    {
        private float _Speed;
        private Random _Random;

        public RandomJitterMovement(float speed)
        {
            _Speed = speed;
            _Random = new Random();
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            float jitterX = (float)(_Random.NextDouble() - 0.5) * 10; // Nhảy ngẫu nhiên trong khoảng [-5, 5]
            position += new Vector2(jitterX, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
