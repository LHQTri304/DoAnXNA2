using System;
using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DoAnXNA2.src.strategyMethod
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
                    AddNewBullets(position);
                    bullets.AddRange(newBullets);
                    newBullets.Clear();
                    ResetShootCoolDown(ref shootCoolDown); // Reset cooldown sau mỗi lần bắn
                });
        }
        protected void ResetShootCoolDown(ref float shootCoolDown)
        {
            shootCoolDown = shotReloading;
        }
        protected void LevelUp()
        {
            if (_Level < 10)
                _Level++;
        }
        protected void LevelDown()
        {
            if (_Level > 1)
                _Level--;
        }
    }
}
