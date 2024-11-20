using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class NoShot : IBaseShootingStrategy
    {
        public NoShot()
        {
            _Speed = 3.5f;
            ShotSound = null;
            newBullets = [];
            ResetShootCoolDown(ref shootCoolDown); // Khởi tạo cooldown ban đầu
        }

        protected override void AddNewBullets(Vector2 position) { }
    }
}
