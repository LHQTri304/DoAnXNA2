using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class EYellow : Enemy
    {
        public EYellow(Vector2 position)
            : base(Textures.textureEnemyYellow, position, new StraightDownMovement(1.5f)) { }
    }
}
