using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class ERed : Enemy
    {
        public ERed(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyRed, position,
                ScoreTable.TenPoints,
                new PerlinMovement(100f, 20f, Textures.EnemyRed),
                new StraightDoubleShot()
            )
        { }
    }
}
