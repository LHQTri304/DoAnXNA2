using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoAnXNA2.src.strategyMethod;

namespace DoAnXNA2.src.sprites
{
    public class EGreen : Enemy
    {
        public EGreen(Game1 game, Vector2 position)
            : base(game, Textures.textureEnemyGreen, position, new ZigZagMovement(1.0f)) { }
    }
}
