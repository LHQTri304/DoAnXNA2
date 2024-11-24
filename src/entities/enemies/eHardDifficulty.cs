using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EBlack : Enemy
{
    public EBlack(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyBlack, position,
            ScoreTable.ThirtyPoints,
            [new SpiralMovement(1.5f), new BounceMovement()],
            [new CircularRing10Shot(), new SpreadFan5Shot(), new ZigzagShot()]
        )
    { }
}

public class EWhite : Enemy
{
    public EWhite(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyWhite, position,
            ScoreTable.ThirtyPoints,
            [new RandomJitterMovement(), new StepwiseMovement(1.8f)],
            [new SpiralDoubleShot(), new StraightSingleShot(), new Wave3Shot()]
        )
    { }
}

public class EGold : Enemy
{
    public EGold(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyGold, position,
            ScoreTable.ThirtyPoints,
            [new StraightDownMovement(2.0f), new TeleportMovement()],
            [new SpreadRandom5Shot(), new VShapeDualShot(), new CircularRing8Shot()]
        )
    { }
}

public class ESilver : Enemy
{
    public ESilver(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemySilver, position,
            ScoreTable.ThirtyPoints,
            [new GravityFallMovement(), new CurvedPathMovement()],
            [new ConvergingShot(), new ZigzagShot(), new SpiralSingleShot()]
        )
    { }
}

public class EMaroon : Enemy
{
    public EMaroon(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyMaroon, position,
            ScoreTable.ThirtyPoints,
            [new DiagonalRight2LMovement(2.5f), new CircularMovement()],
            [new CircularRing3MultiLayerShot(), new Wave3Shot(), new StraightDoubleShot()]
        )
    { }
}

public class ENavy : Enemy
{
    public ENavy(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyNavy, position,
            ScoreTable.ThirtyPoints,
            [new MeteoriteMovement(), new SpiralMovement(1.7f)],
            [new SpiralDoubleShot(), new SpreadTripleShot(), new VShapeDualShot()]
        )
    { }
}

}