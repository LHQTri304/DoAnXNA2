using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class ERed : Enemy
    {
        public ERed(Game1 game, Vector2 position)
            : base(game, Textures.textureEnemyRed, position, new PerlinMovement(555f, 15f, Textures.textureEnemyRed)) { }
    }
}
