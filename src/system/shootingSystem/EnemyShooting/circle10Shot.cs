using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class Circle10Shot : IBaseShootingStrategy
    {
        private float[] shotsRotate = [0, 36, 72, 108, 144, 180, 216, 252, 288, 324];
        public Circle10Shot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            foreach (var shotR in shotsRotate)
                QuickAddBullet(new Vector2(position.X, position.Y), _Speed, shotR);
        }
    }
}
