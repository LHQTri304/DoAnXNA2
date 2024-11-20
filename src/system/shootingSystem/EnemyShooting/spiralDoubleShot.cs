using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SpiralDoubleShot : IBaseShootingStrategy
    {
        private float angle1 = 0;
        private float angle2 = 180;

        public SpiralDoubleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            SetShootCoolDown(0.25, 0.25);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            QuickAddBullet(position, _Speed, angle1);
            QuickAddBullet(position, _Speed, angle2);
            angle1 = (angle1 + 20) % 360;
            angle2 = (angle2 + 20) % 360;
        }
    }
}
