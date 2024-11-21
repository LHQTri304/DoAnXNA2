using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EBlue : Enemy
    {
        public EBlue(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyBlue, position,
                ScoreTable.TenPoints,
                new StraightDownMovement(1.0f),
                new CircularRing10Shot()
            )
        { }
    }
}
