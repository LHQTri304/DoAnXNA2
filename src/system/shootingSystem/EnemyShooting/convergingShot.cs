using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class ConvergingShot : IBaseShootingStrategy
    {
        //Bắn nhiều viên đạn từ các góc khác nhau hội tụ vào giữa.
        private float[] angles = { -45, -15, 0, 15, 45 };

        public ConvergingShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            SetShootCoolDown();
        }

        protected override void AddNewBullets(Vector2 position)
        {
            foreach (var angle in angles)
                QuickAddBullet(position, _Speed, angle);
        }
    }
}
