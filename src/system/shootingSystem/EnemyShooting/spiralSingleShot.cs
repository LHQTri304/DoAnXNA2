using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SpiralSingleShot : IBaseShootingStrategy
    {
        private float angle = 0;

        public SpiralSingleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            QuickAddBullet(position, _Speed, angle);
            angle = (angle + 15) % 360; // Tăng góc xoắn
        }
    }
}
