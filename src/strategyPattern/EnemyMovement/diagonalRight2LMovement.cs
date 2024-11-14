using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class DiagonalRight2LMovement : IMovementStrategy
    {
        private float _Speed;

        public DiagonalRight2LMovement(float speed)
        {
            _Speed = speed;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            position += new Vector2(-_Speed, _Speed * 2 / 3);
            return position;
        }
    }
}