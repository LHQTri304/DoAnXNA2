using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SpreadFan5Shot : IBaseShootingStrategy
    {
        private float[] shotsRotate = { -40, -20, 0, 20, 40 };

        public SpreadFan5Shot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            foreach (var angle in shotsRotate)
                QuickAddBullet(position, _Speed, angle);
        }
    }
}
