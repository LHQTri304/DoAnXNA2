using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class StraightDownMovement : IMovementStrategy
    {
        private float speed;

        public StraightDownMovement(float speed)
        {
            this.speed = speed;
        }

        public void Move(Vector2 position)
        {
            position.Y += speed;
        }
    }
}
