using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public class ERed : Enemy
    {
        public ERed(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyRed, position,
                ScoreTable.TenPoints,
                new PerlinMovement(Textures.EnemyRed, 100f, 20f),
                new StraightDoubleShot()
            )
        { }
    }
}
