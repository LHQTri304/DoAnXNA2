using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EYellow : Enemy
    {
        public EYellow(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyYellow, position,
                ScoreTable.TenPoints,
                new TeleportMovement(),
                new NoShot()
            )
        { }
    }
}
