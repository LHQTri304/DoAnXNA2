using Microsoft.Xna.Framework;
using DoAnXNA2.src.strategyMethod;


namespace DoAnXNA2.src.sprites
{
    public class EYellow : Enemy
    {
        public EYellow(Game1 game, Vector2 position)
            : base(game, Textures.textureEnemyYellow, position, new DiagonalRight2LMovement(1.5f), new StraightDualShot()) { }
    }
}
