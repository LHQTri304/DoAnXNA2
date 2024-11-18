using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class StraightSingleShot : IBaseShootingStrategy
    {
        public StraightSingleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            newBullets.Add(new BulletEnemy(Textures.BulletE, new Vector2(position.X, position.Y), _Speed, 0));
        }
    }
}
