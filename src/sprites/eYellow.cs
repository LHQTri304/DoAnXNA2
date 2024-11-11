using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class EYellow : Enemy
    {
        public EYellow(Texture2D texture, Vector2 position)
            : base(texture, position, new StraightDownMovement(1.5f)) { }
    }
}
