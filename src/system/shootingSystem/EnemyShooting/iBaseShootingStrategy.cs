using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace DoAnXNA2
{
    public abstract class IBaseShootingStrategy
    {
        protected GameTime _GameTime;
        protected float _Speed;
        protected SoundEffect ShotSound;
        protected float shootCoolDown;
        protected double _minCD;
        protected double _maxCD;
        protected List<Bullet> newBullets;
        protected abstract void AddNewBullets(Vector2 position);
        public void Shoot(GameTime gameTime, Vector2 position, List<Bullet> bullets)
        {
            _GameTime = gameTime;
            shootCoolDown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shootCoolDown <= 0)
            {
                ShotSound?.Play();
                AddNewBullets(position);
                bullets.AddRange(newBullets);
                newBullets.Clear();
                ResetShootCoolDown(); // Reset cooldown sau mỗi lần bắn
            }
        }
        protected void SetShootCoolDown(double minCD = 3, double maxCD = 4.5)
        {
            _minCD = minCD;
            _maxCD = maxCD;
        }
        protected void ResetShootCoolDown()
        {
            Random random = new Random();
            shootCoolDown = (float)(random.NextDouble() * (_maxCD - _minCD) + _minCD);
        }
        protected void QuickAddBullet(Vector2 position, float speed, float rotateAngle)
        {
            newBullets.Add(BulletFactory.CreateBullet("Enemy", position, speed, rotateAngle));
        }
    }
}
