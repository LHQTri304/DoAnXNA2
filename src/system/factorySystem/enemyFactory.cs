using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(Game1 game, string type, Vector2 position)
        {
            return type switch
            {
                "Red" => new ERed(game, position),
                "Yellow" => new EYellow(game, position),
                "Green" => new EGreen(game, position),
                "Blue" => new EBlue(game, position),
                _ => null
            };
        }
    }
}
