using System;
using System.Linq;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class EnemyCountHUD : I_HUD
    {
        private int _enemyCount;

        public EnemyCountHUD(SpriteFont font)
            : base(font)
        {
            _enemyCount = 0;
        }

        public override void Update(GameTime gameTime)
        {
            _enemyCount = MainRes.AllEnemies.Count;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string enemyText = $"Enemies: {_enemyCount}";
            spriteBatch.DrawString(Font, enemyText, new Vector2(10, 40), Color.White);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, Font, enemyText, new Vector2(100, 40));
        }
    }
}