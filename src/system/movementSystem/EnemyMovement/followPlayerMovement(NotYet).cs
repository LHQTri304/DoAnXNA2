using System;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class FollowPlayerMovement : IMovementStrategy
    {
        private float _Speed;
        private Vector2 _PlayerPosition;

        public FollowPlayerMovement(float speed, Vector2 playerPosition)
        {
            _Speed = speed;
            _PlayerPosition = playerPosition;
        }

        public Vector2 Move(GameTime gameTime, Vector2 position)
        {
            Vector2 direction = Vector2.Normalize(_PlayerPosition - position);
            position += direction * _Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            return position;
        }
    }

}
