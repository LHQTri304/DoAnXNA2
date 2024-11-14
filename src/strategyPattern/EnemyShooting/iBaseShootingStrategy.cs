using System;
using System.Collections.Generic;
using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public abstract class IBaseShootingStrategy
    {
        protected float _Speed;
        protected float shootCoolDown;
        public abstract void Shoot(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position, List<Bullet> bullets);
        protected void ResetShootCoolDown(ref float shootCoolDown)
        {
            Random random = new Random();
            shootCoolDown = (float)(random.NextDouble() * 1.5 + 3);
        }
    }
}
