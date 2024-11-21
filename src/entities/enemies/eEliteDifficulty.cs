using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EGray : Enemy
{
    public EGray(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyGray, position,
            ScoreTable.TwentyPoints,
            [new RandomJitterMovement()],
            [new CircularRing8Shot(), new ZigzagShot()]
        )
    { }
}

public class ECyan : Enemy
{
    public ECyan(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyCyan, position,
            ScoreTable.TwentyPoints,
            [new StepwiseMovement(2.0f)],
            [new SpiralSingleShot(), new StraightDoubleShot()]
        )
    { }
}

public class ELime : Enemy
{
    public ELime(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyLime, position,
            ScoreTable.TwentyPoints,
            [new CurvedPathMovement()],
            [new Wave3Shot(), new SpreadRandom5Shot()]
        )
    { }
}

public class EPink : Enemy
{
    public EPink(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyPink, position,
            ScoreTable.TwentyPoints,
            [new DiagonalLeft2RMovement(1.5f)],
            [new VShapeDualShot(), new ConvergingShot()]
        )
    { }
}

public class EBrown : Enemy
{
    public EBrown(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyBrown, position,
            ScoreTable.TwentyPoints,
            [new BounceMovement()],
            [new SpreadFan5Shot(), new CircularRing3MultiLayerShot()]
        )
    { }
}

public class ETeal : Enemy
{
    public ETeal(Game1 game, Vector2 position)
        : base(
            game, Textures.EnemyTeal, position,
            ScoreTable.TwentyPoints,
            [new SpiralMovement(1.2f)],
            [new SpiralDoubleShot(), new Wave3Shot()]
        )
    { }
}

}
