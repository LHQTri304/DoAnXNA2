using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class StraightDoubleShot : IBaseShootingStrategy
    {
        public StraightDoubleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            QuickAddBullet(new Vector2(position.X + 15, position.Y), _Speed, 0);
            QuickAddBullet(new Vector2(position.X - 15, position.Y), _Speed, 0);
        }
    }
}
