using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class WaveShot : IBaseShootingStrategy
    {
        private int waveStep = 0;

        public WaveShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            float baseAngle = waveStep * 10; // Tăng góc theo bước
            QuickAddBullet(position, _Speed, baseAngle);
            QuickAddBullet(position, _Speed, baseAngle + 20);
            QuickAddBullet(position, _Speed, baseAngle - 20);
            waveStep = (waveStep + 1) % 36; // Reset sau 36 bước
        }
    }
}
