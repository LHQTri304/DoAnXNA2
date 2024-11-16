using System;
using System.Linq;
using DoAnXNA2.src.utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2.src.UI
{
    public class EnemyCountHUD : I_HUD
    {
        private int _enemyCount;

        public EnemyCountHUD(Game1 game, SpriteFont font)
            : base(game, font)
        {
            _enemyCount = 0;
        }

        public override void Update(GameTime gameTime)
        {
            _enemyCount = _game._allSpawners.SelectMany(spawner => spawner.Enemies).ToList().Count;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string enemyText = $"Enemies: {_enemyCount}";
            //spriteBatch.DrawString(Font, enemyText, new Vector2(10, 40), Color.White);
            SimplifyDrawing.HandleCenteredText(spriteBatch, Font, enemyText, new Vector2(10, 40));
        }
    }
}