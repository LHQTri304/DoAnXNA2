using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SpreadTripleShot : IBaseShootingStrategy
    {
        public SpreadTripleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            QuickAddBullet(position, _Speed, -30); // Chéo trái
            QuickAddBullet(position, _Speed, 0);   // Thẳng
            QuickAddBullet(position, _Speed, 30);  // Chéo phải
        }
    }
}
