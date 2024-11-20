using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class ZigzagShot : IBaseShootingStrategy
    {
        private bool toggleDirection = true;

        public ZigzagShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            ResetShootCoolDown(ref shootCoolDown);
        }

        protected override void AddNewBullets(Vector2 position)
        {
            float angle = toggleDirection ? -15 : 15;
            QuickAddBullet(position, _Speed, angle);
            toggleDirection = !toggleDirection; // Đổi hướng góc bắn
        }
    }
}
