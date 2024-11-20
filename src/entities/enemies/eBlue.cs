using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EBlue : Enemy
    {
        public EBlue(Game1 game, Vector2 position)
            : base(game, Textures.EnemyBlue, position, ScoreTable.SinglePoint, new DiagonalLeft2RMovement(2.5f), new StraightSingleShot()) { }
    }
}
