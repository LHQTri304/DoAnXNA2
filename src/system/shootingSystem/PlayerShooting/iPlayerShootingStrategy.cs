using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2
{
    public abstract class IPlayerShootingStrategy
    {
        protected int _Level; //1->10
        protected float _Speed;
        protected float shootCoolDown;
        protected float shotReloading = 0.1f;
        protected List<Bullet> newBullets;
        protected abstract void AddNewBullets(Vector2 position);
        public void Shoot(float elapsedTime, MouseState mstate, Vector2 position, List<Bullet> bullets)
        {
            if (shootCoolDown > 0)
                shootCoolDown -= elapsedTime;
            else
                InputUtilities.HandleMouseClick(mstate.LeftButton, 0, () =>
                {
                    Soundtrack.PlayerShot.Play();
                    AddNewBullets(position);
                    bullets.AddRange(newBullets);
                    newBullets.Clear();
                    ResetShootCoolDown(); // Reset cooldown sau mỗi lần bắn
                });
        }
        protected void ResetShootCoolDown()
        {
            shootCoolDown = shotReloading;
        }
        protected void QuickAddBullet(Vector2 position, float speed, float rotateAngle)
        {
            newBullets.Add(BulletFactory.CreateBullet("Player", position, speed, rotateAngle));
        }
    }
}
