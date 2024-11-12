using DoAnXNA2.src.sprites;
using Microsoft.Xna.Framework;

namespace DoAnXNA2.src.strategyMethod
{
    public interface IShootingStrategy
    {
        BulletEnemy Shoot(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position, BulletEnemy bullets);
    }
}
