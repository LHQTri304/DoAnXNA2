using Microsoft.Xna.Framework;
using DoAnXNA2.src.strategyMethod;


namespace DoAnXNA2
{
    public class EGreen : Enemy
    {
        public EGreen(Game1 game, Vector2 position)
            : base(game, Textures.EnemyGreen, position, ScoreTable.TenPoints, new StraightDownMovement(1.0f), new Circle10Shot()) { }
    }
}
