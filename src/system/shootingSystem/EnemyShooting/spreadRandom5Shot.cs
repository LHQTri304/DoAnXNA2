using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class SpreadRandom5Shot : IBaseShootingStrategy
    {
        private Random random = new Random();

        public SpreadRandom5Shot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            for (int i = 0; i < 5; i++)
            {
                float angle = (float)(random.NextDouble() * 360); // Góc ngẫu nhiên từ 0 đến 360
                QuickAddBullet(position, _Speed, angle);
            }
        }
    }
}