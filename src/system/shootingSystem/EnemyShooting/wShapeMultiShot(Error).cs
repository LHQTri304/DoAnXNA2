using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class WShapeMultiShot : IBaseShootingStrategy
    {
        private float wShapeShootCoolDown = 0;
        private float delayBetweenShots = 0.25f;
        private int patternIndex = 0;
        private float[] patternAngles = { -30, 30, -15, 15, 0 }; // Các góc tạo thành chữ "W"

        public WShapeMultiShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {

            wShapeShootCoolDown -= (float)_GameTime.ElapsedGameTime.TotalSeconds;

            if (wShapeShootCoolDown <= 0)
            {
                QuickAddBullet(position, _Speed, patternAngles[patternIndex]);
                patternIndex = (patternIndex + 1) % patternAngles.Length; // Chuyển sang góc tiếp theo
                wShapeShootCoolDown = delayBetweenShots;
            }
        }
    }
}
