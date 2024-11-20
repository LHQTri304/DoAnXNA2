using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public interface IMovementStrategy
    {
        Vector2 Move(GameTime gameTime, GraphicsDeviceManager graphics, Vector2 position);
    }
}
