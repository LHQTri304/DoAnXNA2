using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class ERed : Enemy
    {
        public ERed(Texture2D texture, Vector2 position)
            : base(texture, position, new ZigZagMovement(2.0f)) { }
    }
}
