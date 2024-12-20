using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class PerlinMovement : IMovementStrategy
    {
        //Quản lý di chuyển ngẫu nhiên
        private float horizontalOffset; // Biến để lưu giá trị ngẫu nhiên (Perlin noise)
        private static float perlinNoiseOffset = 0; // Giá trị để tính Perlin noise cho mỗi kẻ địch
        private float _HorizontalSpeed;
        private float _VerticalSpeed;

        // Quản lý giới hạn di chuyển bên trong màn hình
        private bool isCollidedWithWall;
        private float wallCollisionCoolDown;
        private const float wallCollisionCoolDownTime = 0.75f;

        //Bonus
        private Texture2D _Texture;

        public PerlinMovement(Texture2D texture, float horizontalSpeed = 200f, float verticalSpeed = 100f)
        {
            horizontalOffset = perlinNoiseOffset;
            perlinNoiseOffset += (float)(new Random().NextDouble() * 999);
            _HorizontalSpeed = horizontalSpeed;
            _VerticalSpeed = verticalSpeed;
            _Texture = texture;
        }

        public Vector2 Move(GameTime gameTime, Vector2 position)
        {
            //Move down
            float MovingY = _VerticalSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Move horizontal randomly by PerlinNoise
            float perlinValue = MathHelper.Lerp(-1, 1, (float)SimplexNoise.Noise.CalcPixel2D((int)horizontalOffset, 0, 0.05f) / 255f);
            horizontalOffset += 0.1f;
            float moveValue = perlinValue * _HorizontalSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float MovingX = MoveAfterCollisionWithWall(gameTime, position, moveValue);
            //Complete the new position
            position += new Vector2(MovingX, MovingY);
            return position;
        }


        public float MoveAfterCollisionWithWall(GameTime gameTime, Vector2 position, float moveValue)
        {
            if (position.X < _Texture.Width / 2)
            {
                isCollidedWithWall = true;
                wallCollisionCoolDown = wallCollisionCoolDownTime;
            }
            else if (position.X > MainRes.ScreenWidth - _Texture.Width / 2)
            {
                wallCollisionCoolDown = wallCollisionCoolDownTime;
            }

            if (wallCollisionCoolDown > 0)
            {
                wallCollisionCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                return isCollidedWithWall
                    ? Math.Abs(moveValue)
                    : -Math.Abs(moveValue);
            }
            else
            {
                isCollidedWithWall = false;
                return moveValue;
            }
        }
    }
}
