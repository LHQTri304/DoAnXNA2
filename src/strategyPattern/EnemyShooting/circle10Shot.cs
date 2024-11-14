using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public class Circle10Shot : IBaseShootingStrategy
    {
        private float[] shotsRotate = [0, 36, 72, 108, 144, 180, 216, 252, 288, 324];
        public Circle10Shot()
        {
            _Speed = 3.5f;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            foreach (var shotR in shotsRotate)
                newBullets.Add(new BulletEnemy(Textures.textureBulletE, new Vector2(position.X, position.Y), _Speed, shotR));
        }
    }
}
