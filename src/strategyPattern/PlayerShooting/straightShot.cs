using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class StraightShot : IPlayerShootingStrategy
    {
        public StraightShot()
        {
            _Level = 10;
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

            foreach (var p in pDiff)
                newBullets.Add(new BulletPlayer(Textures.textureBulletP, new Vector2(position.X + p.X, position.Y + p.Y), _Speed, 0));
        }
    }
}
