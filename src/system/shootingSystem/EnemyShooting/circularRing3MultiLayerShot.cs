using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class CircularRing3MultiLayerShot : IBaseShootingStrategy
    {
        private float[] layers = { 8, 12, 16 }; // Số viên đạn trên mỗi lớp

        public CircularRing3MultiLayerShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = new List<Bullet>();
            SetShootCoolDown();
        }

        protected override void AddNewBullets(Vector2 position)
        {
            foreach (var layer in layers)
            {
                float step = 360f / layer;
                for (int i = 0; i < layer; i++)
                {
                    QuickAddBullet(position, _Speed, i * step);
                }
            }
        }
    }
}
