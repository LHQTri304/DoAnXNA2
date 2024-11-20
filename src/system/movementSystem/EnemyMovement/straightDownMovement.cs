using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class StraightDownMovement : IMovementStrategy
    {
        private float _Speed;

        public StraightDownMovement(float speed)
        {
            _Speed = speed;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            position += new Vector2(0, _Speed);
            return position;
        }
    }
}
