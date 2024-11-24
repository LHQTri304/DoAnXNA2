using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EYellow : Enemy
    {
        public EYellow(Vector2 position)
            : base(
                Textures.EnemyYellow, position,
                ScoreTable.TenPoints,
                [new TeleportMovement()],
                [new StraightDoubleShot()]
            )
        { }
    }

    public class ERed : Enemy
    {
        public ERed(Vector2 position)
            : base(
                Textures.EnemyRed, position,
                ScoreTable.TenPoints,
                [new PerlinMovement(Textures.EnemyRed, 100f, 35f)],
                [new SpiralSingleShot()]
            )
        { }
    }

    public class EGreen : Enemy
    {
        public EGreen(Vector2 position)
            : base(
                Textures.EnemyGreen, position,
                ScoreTable.TenPoints,
                [new StraightDownMovement(1.0f)],
                [new CircularRing10Shot()]
            )
        { }
    }

    public class EBlue : Enemy
    {
        public EBlue(Vector2 position)
            : base(
                Textures.EnemyBlue, position,
                ScoreTable.TenPoints,
                [new StraightDownMovement(1.5f)],
                [new SpreadTripleShot()]
            )
        { }
    }

    public class EOrange : Enemy
    {
        public EOrange(Vector2 position)
            : base(
                Textures.EnemyOrange, position,
                ScoreTable.TenPoints,
                [new DiagonalRight2LMovement(1.0f)],
                [new StraightSingleShot()]
            )
        { }
    }

    public class EPurple : Enemy
    {
        public EPurple(Vector2 position)
            : base(
                Textures.EnemyPurple, position,
                ScoreTable.TenPoints,
                [new GravityFallMovement()],
                [new NoShot()]
            )
        { }
    }
}
