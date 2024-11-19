using System.Collections.Generic;
using System.Linq;
using DoAnXNA2;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public struct BulletInfo
    {
        public Vector2 Position;
        public float Rotate; // Góc quay của viên đạn

        public BulletInfo(Vector2 position, float rotate)
        {
            Position = position;
            Rotate = rotate;
        }
    }

    public class ConicalShot : IPlayerShootingStrategy
    {
        public ConicalShot(int level)
        {
            _Level = level;
            _Speed = 5.5f;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            List<Vector2> pDiff = _Level switch
            {
                1 => [new(0, -15)],
                2 => [new(-10, 0), new(10, 0)],
                3 => [new(-10, 0), new(10, 0), new(0, -15)],
                4 => [new(-10, 0), new(10, 0), new(-5, -15), new(5, -15)],
                5 => [new(-15, 0), new(15, 0), new(0, -15), new(-5, -10), new(5, -10)],
                6 => [new(-15, 0), new(15, 0), new(0, -15), new(-10, -10), new(10, -10)],
                7 => [new(-15, 0), new(15, 0), new(0, -15), new(-10, -15), new(10, -15), new(0, -30)],
                8 => [new(-15, 0), new(15, 0), new(0, -15), new(-5, -10), new(5, -10), new(-5, -20), new(5, -20)],
                9 => [new(-20, 0), new(20, 0), new(0, -15), new(-10, -10), new(10, -10), new(-10, -20), new(10, -20), new(0, -30)],
                10 => [new(-20, 0), new(20, 0), new(0, -15), new(-15, -10), new(15, -10), new(-5, -20), new(5, -20), new(-5, -30), new(5, -30)],
                _ => [], // Default case
            };

            List<float> rDiff = _Level switch
            {
                1 => [0],
                2 => [-15, 15],
                3 => [-15, 15, 0],
                4 => [-20, 20, -10, 10],
                5 => [-20, 20, -10, 10, 0],
                6 => [-25, 25, -15, 15, -5, 5],
                7 => [-25, 25, -15, 15, -5, 5, 0],
                8 => [-30, 30, -20, 20, -10, 10, -5, 5],
                9 => [-30, 30, -20, 20, -10, 10, -5, 5, 0],
                10 => [-30, 30, -25, 25, -15, 15, -5, 5, -10, 10],

                _ => [], // Default case
            };

            List<BulletInfo> bulletInfos = pDiff
                .Select((position, index) => new BulletInfo(position, rDiff[index]))
                .ToList();


            foreach (var item in bulletInfos)
                QuickAddBullet(position + item.Position, _Speed, item.Rotate);
        }
    }
}
