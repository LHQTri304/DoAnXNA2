using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class EGreen : Enemy
    {
        public EGreen(Texture2D texture, Vector2 position)
            : base(texture, position, new ZigZagMovement(1.0f)) { }
    }
}
