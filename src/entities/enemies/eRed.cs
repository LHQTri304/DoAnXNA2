using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class ERed : Enemy
    {
        public ERed(Game1 game, Vector2 position)
            : base(game, Textures.EnemyRed, position, ScoreTable.FivePoints, new PerlinMovement(555f, 15f, Textures.EnemyRed), new StraightSingleShot()) { }
    }
}
