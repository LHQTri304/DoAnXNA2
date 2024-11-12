using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class EBlue : Enemy
    {
        public EBlue(Vector2 position)
            : base(Textures.textureEnemyBlue, position, new StraightDownMovement(2.5f)) { }
    }
}
