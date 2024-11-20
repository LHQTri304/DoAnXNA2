using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class BurstTripleShot : IBaseShootingStrategy
    {
        private float burstShootCoolDown = 0;
        private float delayBetweenShots = 0.25f;
        private int shotsLeft = 0;

        public BurstTripleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            SetShootCoolDown();
        }

        protected override void AddNewBullets(Vector2 position)
        {
            burstShootCoolDown -= (float)_GameTime.ElapsedGameTime.TotalSeconds;

            if (burstShootCoolDown <= 0 && shotsLeft == 0)
            {
                shotsLeft = 3; // Khởi tạo loạt đạn mới
                burstShootCoolDown = delayBetweenShots; // Đặt khoảng cách giữa mỗi viên
            }

            if (shotsLeft > 0 && burstShootCoolDown <= 0)
            {
                QuickAddBullet(position, _Speed, 0);
                shotsLeft--;
                burstShootCoolDown = delayBetweenShots;
            }
        }
    }
}
