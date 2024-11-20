using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class StraightSingleShot : IBaseShootingStrategy
    {
        public StraightSingleShot()
        {
            _Speed = 3.5f;
            ShotSound = Soundtrack.EnemyShot;
            newBullets = [];
            SetShootCoolDown(); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position)
        {
            QuickAddBullet(new Vector2(position.X, position.Y), _Speed, 0);
        }
    }
}
