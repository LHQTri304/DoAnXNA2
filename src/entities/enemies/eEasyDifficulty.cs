using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EYellow : Enemy
    {
        public EYellow(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyYellow, position,
                ScoreTable.TenPoints,
                [new TeleportMovement()],
                [new StraightDoubleShot()]
            )
        { }
    }

    public class ERed : Enemy
    {
        public ERed(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyRed, position,
                ScoreTable.TenPoints,
                [new PerlinMovement(Textures.EnemyRed, 100f, 35f)],
                [new SpiralSingleShot()]
            )
        { }
    }

    public class EGreen : Enemy
    {
        public EGreen(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyGreen, position,
                ScoreTable.TenPoints,
                [new StraightDownMovement(1.0f)],
                [new CircularRing10Shot()]
            )
        { }
    }

    public class EBlue : Enemy
    {
        public EBlue(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyBlue, position,
                ScoreTable.TenPoints,
                [new StraightDownMovement(1.5f)],
                [new SpreadTripleShot()]
            )
        { }
    }

    public class EOrange : Enemy
    {
        public EOrange(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyOrange, position,
                ScoreTable.TenPoints,
                [new DiagonalRight2LMovement(1.0f)],
                [new StraightSingleShot()]
            )
        { }
    }

    public class EPurple : Enemy
    {
        public EPurple(Game1 game, Vector2 position)
            : base(
                game, Textures.EnemyPurple, position,
                ScoreTable.TenPoints,
                [new GravityFallMovement()],
                [new NoShot()]
            )
        { }
    }
}
