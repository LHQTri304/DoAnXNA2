using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class VShapeDualShot : IBaseShootingStrategy
    {
        public VShapeDualShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            SetShootCoolDown();
        }

        protected override void AddNewBullets(Vector2 position)
        {
            QuickAddBullet(position, _Speed, -15); // Góc lệch trái
            QuickAddBullet(position, _Speed, 15);  // Góc lệch phải
        }
    }
}
