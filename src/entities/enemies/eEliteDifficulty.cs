using Microsoft.Xna.Framework;


namespace DoAnXNA2
{
    public class EGray : Enemy
{
    public EGray(Vector2 position)
        : base(
            Textures.EnemyGray, position,
            ScoreTable.TwentyPoints,
            [new RandomJitterMovement()],
            [new CircularRing8Shot(), new ZigzagShot()]
        )
    { }
}

public class ECyan : Enemy
{
    public ECyan(Vector2 position)
        : base(
            Textures.EnemyCyan, position,
            ScoreTable.TwentyPoints,
            [new StepwiseMovement(2.0f)],
            [new SpiralSingleShot(), new StraightDoubleShot()]
        )
    { }
}

public class ELime : Enemy
{
    public ELime(Vector2 position)
        : base(
            Textures.EnemyLime, position,
            ScoreTable.TwentyPoints,
            [new CurvedPathMovement()],
            [new Wave3Shot(), new SpreadRandom5Shot()]
        )
    { }
}

public class EPink : Enemy
{
    public EPink(Vector2 position)
        : base(
            Textures.EnemyPink, position,
            ScoreTable.TwentyPoints,
            [new DiagonalLeft2RMovement(1.5f)],
            [new VShapeDualShot(), new ConvergingShot()]
        )
    { }
}

public class EBrown : Enemy
{
    public EBrown(Vector2 position)
        : base(
            Textures.EnemyBrown, position,
            ScoreTable.TwentyPoints,
            [new BounceMovement()],
            [new SpreadFan5Shot(), new CircularRing3MultiLayerShot()]
        )
    { }
}

public class ETeal : Enemy
{
    public ETeal(Vector2 position)
        : base(
            Textures.EnemyTeal, position,
            ScoreTable.TwentyPoints,
            [new SpiralMovement(1.2f)],
            [new SpiralDoubleShot(), new Wave3Shot()]
        )
    { }
}

}
