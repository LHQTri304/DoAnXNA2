using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.sprites;

namespace DoAnXNA2.src.factoryMethod
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(string type, Vector2 position)
        {
            return type switch
            {
                "Red" => new ERed(position),
                "Yellow" => new EYellow(position),
                "Green" => new EGreen(position),
                "Blue" => new EBlue(position),
                _ => null
            };
        }
    }
}
