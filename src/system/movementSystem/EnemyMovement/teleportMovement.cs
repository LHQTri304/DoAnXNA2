using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class TeleportMovement : IMovementStrategy
    {
        private float _Speed;
        private float _TeleportInterval;
        private float _TimeSinceLastTeleport;
        private float _SmoothMoveX;
        private Random _Random;

        public TeleportMovement(float speed = 50f)
        {
            _Speed = speed;
            _TimeSinceLastTeleport = 0;
            _SmoothMoveX = 0;
            _Random = new Random();
            RenewTeleportInterval();
        }

        private void RenewTeleportInterval()
        {
            _TeleportInterval = (float)_Random.NextDouble() * 10;
        }

        public Vector2 Move(GameTime gameTime, Vector2 position)
        {
            _TimeSinceLastTeleport += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_TimeSinceLastTeleport >= _TeleportInterval)
            {
                _TimeSinceLastTeleport = 0;
                position.X = _Random.Next(0, MainRes.ScreenWidth);
                RenewTeleportInterval();
            }
            else
                position.X += (float)Math.Cos(_SmoothMoveX += _TimeSinceLastTeleport);
            position += new Vector2(0, _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            return position;
        }
    }
}
