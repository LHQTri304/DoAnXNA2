using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.sprites;
using System.Collections.Generic;

namespace DoAnXNA2.src.factoryMethod
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
