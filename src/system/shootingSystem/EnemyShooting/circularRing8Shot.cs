using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class CircularRing8Shot : IBaseShootingStrategy
    {
        private float[] shotsRotate = { 0, 45, 90, 135, 180, 225, 270, 315 };

        public CircularRing8Shot()
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
