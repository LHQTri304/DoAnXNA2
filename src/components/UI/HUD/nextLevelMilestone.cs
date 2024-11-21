using System;
using DoAnXNA2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public class NextLevelMilestoneHUD : I_HUD
    {
        private int _playerCurrentLevel;

        public NextLevelMilestoneHUD(Game1 game, SpriteFont font)
            : base(game, font)
        {
            _playerCurrentLevel = 1;
        }

        public override void Update(GameTime gameTime)
        {
            _playerCurrentLevel = _game1.PlayerShip.CurrentLevel;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string text = $"To next LV: {ScoreTable.MilestoneLv0to10[_playerCurrentLevel + 1]}";
            spriteBatch.DrawString(Font, text, new Vector2(10, _game1.VirtualHeight - 40), Color.White);
            //SimplifyDrawing.HandleCenteredText(spriteBatch, Font, timeText, new Vector2(100, 10));
        }
    }
}