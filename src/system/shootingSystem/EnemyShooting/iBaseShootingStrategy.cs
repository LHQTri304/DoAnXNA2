using System;
using System.Collections.Generic;
using DoAnXNA2.src.factoryMethod;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace DoAnXNA2.src.strategyMethod
{
    public abstract class IBaseShootingStrategy
    {
        protected float _Speed;
        protected SoundEffect ShotSound;
        protected float shootCoolDown;
        protected List<Bullet> newBullets;
        protected abstract void AddNewBullets(Vector2 position);
        public void Shoot(GameTime gameTime, Vector2 position, List<Bullet> bullets)
        {
            shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shootCoolDown <= 0)
            {
                ShotSound?.Play();
                AddNewBullets(position);
                bullets.AddRange(newBullets);
                newBullets.Clear();
                ResetShootCoolDown(ref shootCoolDown); // Reset cooldown sau mỗi lần bắn
            }
        }
        protected void ResetShootCoolDown(ref float shootCoolDown)
        {
            Random random = new Random();
            shootCoolDown = (float)(random.NextDouble() * 1.5 + 3);
        }
        protected void QuickAddBullet(Vector2 position, float speed, float rotateAngle)
        {
            newBullets.Add(BulletFactory.CreateBullet("Enemy", position, speed, rotateAngle));
        }
    }
}
