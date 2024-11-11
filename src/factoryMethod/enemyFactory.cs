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
                "Red" => new ERed(Textures.textureEnemy, position),
                "Yellow" => new EYellow(Textures.textureEnemy, position),
                "Green" => new EGreen(Textures.textureEnemy, position),
                "Blue" => new EBlue(Textures.textureEnemy, position),
                _ => null
            };
        }
    }
}
