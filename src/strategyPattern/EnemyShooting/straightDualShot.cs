using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class StraightDualShot : IBaseShootingStrategy
    {
        public StraightDualShot()
        {
            _Speed = 3.5f;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            newBullets.Add(new BulletEnemy(Textures.BulletE, new Vector2(position.X + 15, position.Y), _Speed, 0));
            newBullets.Add(new BulletEnemy(Textures.BulletE, new Vector2(position.X - 15, position.Y), _Speed, 0));
        }
    }
}
