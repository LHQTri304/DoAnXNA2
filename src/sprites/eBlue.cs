using Microsoft.Xna.Framework;
using DoAnXNA2.src.strategyMethod;


namespace DoAnXNA2.src.sprites
{
    public class EBlue : Enemy
    {
        public EBlue(Game1 game, Vector2 position)
            : base(game, Textures.textureEnemyBlue, position, new StraightDownMovement(2.5f), new SingleStraightDownShot()) { }
    }
}
