using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class TeleportMovement : IMovementStrategy
    {
        private float _Speed;
        private float _TeleportInterval;
        private float _TimeSinceLastTeleport;
        private Random _Random;

        public TeleportMovement(float speed, float teleportInterval)
        {
            _Speed = speed;
            _TeleportInterval = teleportInterval;
            _TimeSinceLastTeleport = 0;
            _Random = new Random();
        }

        public Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position)
        {
            _TimeSinceLastTeleport += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_TimeSinceLastTeleport >= _TeleportInterval)
            {
                _TimeSinceLastTeleport = 0;
                position.X = _Random.Next(0, graphics.PreferredBackBufferWidth);
            }
            position += new Vector2(0, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }

}
