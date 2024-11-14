using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class SingleStraightDownShot : IBaseShootingStrategy
    {
        public SingleStraightDownShot()
        {
            _Speed = 3.5f;
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        public override void Shoot(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position, List<Bullet> bullets)
        {
            shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shootCoolDown <= 0)
            {
                bullets.Add(new BulletEnemy(Textures.textureBulletE, new Vector2(position.X, position.Y), _Speed));
                ResetShootCoolDown(ref shootCoolDown); // Reset cooldown sau mỗi lần bắn
            }
        }
    }
}
