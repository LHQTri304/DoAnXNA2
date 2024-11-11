using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class ZigZagMovement : IMovementStrategy
    {
        private float speed;

        public ZigZagMovement(float speed)
        {
            this.speed = speed;
        }

        public void Move(Vector2 position)
        {
            position.X += speed;
            position.Y += speed * (float)System.Math.Sin(position.X * 0.1f);
        }
    }
}
