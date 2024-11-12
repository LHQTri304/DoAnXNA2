using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class StraightDownBullet : IShootingStrategy
    {
        private float _Speed;

        public StraightDownBullet()
        {
            _Speed = 3.5f;
        }

        public BulletEnemy Shoot(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position, BulletEnemy bullets)
        {
            return bullets;
        }
    }
}
