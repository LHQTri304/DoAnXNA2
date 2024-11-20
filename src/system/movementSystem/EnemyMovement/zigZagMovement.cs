using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class ZigZagMovement : IMovementStrategy
    {
        private float _Speed;

        public ZigZagMovement(float speed)
        {
            _Speed = speed;
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            position += new Vector2(_Speed, _Speed * (float)System.Math.Sin(position.X * 0.1f));
            return position;
        }
    }
}
