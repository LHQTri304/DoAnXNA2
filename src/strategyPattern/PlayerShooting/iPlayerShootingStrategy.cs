using System;
using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public abstract class IPlayerShootingStrategy
    {
        protected float _Speed;
        protected float shootCoolDown;
        protected List<Bullet> newBullets;
        protected abstract void AddNewBullets(Vector2 position);
        public void Shoot(GameTime gameTime, Vector2 position, List<Bullet> bullets)
        {
            shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shootCoolDown <= 0)
            {
                AddNewBullets(position);
                bullets.AddRange(newBullets);
                ResetShootCoolDown(ref shootCoolDown); // Reset cooldown sau mỗi lần bắn
            }
        }
        protected void ResetShootCoolDown(ref float shootCoolDown)
        {
            Random random = new Random();
            shootCoolDown = (float)(random.NextDouble() * 1.5 + 3);
        }
    }
}